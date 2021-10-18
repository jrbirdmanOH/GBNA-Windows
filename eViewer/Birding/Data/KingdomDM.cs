using System.Collections.Generic;
using System.Data;

namespace Thayer.Birding.Data
{
	internal class KingdomDM
	{
		private static KingdomDM instance = new KingdomDM();

		private KingdomDM()
		{
		}

		public static KingdomDM Instance
		{
			get
			{
				return instance;
			}
		}

		public List<Kingdom> GetList(int taxonomyID)
		{
			List<Kingdom> list = new List<Kingdom>();

			Dictionary<int, KingdomNode> kingdoms = new Dictionary<int, KingdomNode>();

			IDbConnection conn = ApplicationSettings.CreateConnection();
			IDbCommand cmd = null;
			IDataReader reader = null;
			try
			{
				cmd = conn.CreateCommand();
				cmd.CommandText = "SELECT cl.KingdomID, cl.PhylaID, cl.ClassID, cl.OrderID, cl.FamilyID, cl.GenusID, k.Kingdom, p.Phyla, c.Class, o.[Order], f.Family, g.Genus, k.Description, p.Description, c.Description, o.Description, f.Description, g.description fROM Class AS c,Classifications AS cl,Family AS f,Genus AS g,Kingdom AS k,[Order] AS o,Phyla AS p WHERE o.OrderID=cl.OrderID AND c.ClassID=cl.ClassID AND p.PhylaID=cl.PhylaID AND k.KingdomID=cl.KingdomID AND f.FamilyID=cl.FamilyID AND g.GenusID=cl.GenusID AND cl.TaxonomyID=:TaxonomyID ORDER BY cl.SortOrder";
				cmd.CommandType = CommandType.Text;

				IDbDataParameter taxonomyParam = cmd.CreateParameter();
				taxonomyParam.ParameterName = ":TaxonomyID";
				taxonomyParam.Value = taxonomyID;
				cmd.Parameters.Add(taxonomyParam);

				conn.Open();
				reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					int kingdomID = reader.GetInt32(0);
					int phylaID = reader.GetInt32(1);
					int classID = reader.GetInt32(2);
					int orderID = reader.GetInt32(3);
					int familyID = reader.GetInt32(4);
					int genusID = reader.GetInt32(5);

					KingdomNode kingdomNode;
					if (!kingdoms.TryGetValue(kingdomID, out kingdomNode))
					{
						Kingdom kingdom = new Kingdom();

						kingdom.ID = reader.GetInt32(0);
						kingdom.Name = reader.GetString(6);
						kingdom.Description = reader.GetString(12);

						list.Add(kingdom);

						kingdomNode = new KingdomNode(kingdom, new Dictionary<int, PhylaNode>());
						kingdoms[kingdomID] = kingdomNode;
					}

					PhylaNode phylumNode;
					if (!kingdomNode.Phyla.TryGetValue(phylaID, out phylumNode))
					{
						Phylum phylum = new Phylum();

						phylum.ID = phylaID;
						phylum.Name = reader.GetString(7);
						phylum.Description = reader.GetString(13);

						kingdomNode.Kingdom.Phyla.Add(phylum);

						phylumNode = new PhylaNode(phylum, new Dictionary<int, ClassNode>());
						kingdomNode.Phyla[phylaID] = phylumNode;
					}

					ClassNode classNode;
					if (!phylumNode.Classes.TryGetValue(classID, out classNode))
					{
						Class cls = new Class();

						cls.ID = classID;
						cls.Name = reader.GetString(8);
						cls.Description = reader.GetString(14);

						phylumNode.Phyla.Classes.Add(cls);

						classNode = new ClassNode(cls, new Dictionary<int, OrderNode>());
						phylumNode.Classes.Add(classID, classNode);
					}

					OrderNode orderNode;
					if (!classNode.Orders.TryGetValue(orderID, out orderNode))
					{
						Order order = new Order();

						order.ID = orderID;
						order.Name = reader.GetString(9);
						order.Description = reader.GetString(15);

						classNode.Class.Orders.Add(order);

						orderNode = new OrderNode(order, new Dictionary<int, FamilyNode>());
						classNode.Orders.Add(orderID, orderNode);
					}

					FamilyNode familyNode;
					if (!orderNode.Families.TryGetValue(familyID, out familyNode))
					{
						Family family = new Family();

						family.ID = familyID;
						family.Name = reader.GetString(10);
						family.Description = reader.GetString(16);

						orderNode.Order.Families.Add(family);

						familyNode = new FamilyNode(family, new Dictionary<int, Genus>());
						orderNode.Families.Add(familyID, familyNode);
					}

					Genus genus;
					if (!familyNode.Genus.TryGetValue(genusID, out genus))
					{
						genus = new Genus();

						genus.ID = genusID;
						genus.Name = reader.GetString(11);
						genus.Description = reader.IsDBNull(17) ? string.Empty : reader.GetString(17);

						familyNode.Family.Genera.Add(genus);

						familyNode.Genus.Add(genusID, genus);
					}
				}
			}
			finally
			{
				if (reader != null)
				{
					reader.Close();
				}

				if (cmd != null)
				{
					cmd.Dispose();
				}

				if (conn != null)
				{
					conn.Close();
				}
			}

			return list;
		}

		private struct KingdomNode
		{
			public Kingdom Kingdom;
			public Dictionary<int, PhylaNode> Phyla;

			public KingdomNode(Kingdom kingdom, Dictionary<int, PhylaNode> phyla)
			{
				Kingdom = kingdom;
				Phyla = phyla;
			}
		}

		private struct PhylaNode
		{
			public Phylum Phyla;
			public Dictionary<int, ClassNode> Classes;

			public PhylaNode(Phylum phyla, Dictionary<int, ClassNode> classes)
			{
				Phyla = phyla;
				Classes = classes;
			}
		}

		private struct ClassNode
		{
			public Class Class;
			public Dictionary<int, OrderNode> Orders;

			public ClassNode(Class cls, Dictionary<int, OrderNode> orders)
			{
				Class = cls;
				Orders = orders;
			}
		}

		private struct OrderNode
		{
			public Order Order;
			public Dictionary<int, FamilyNode> Families;

			public OrderNode(Order order, Dictionary<int, FamilyNode> families)
			{
				Order = order;
				Families = families;
			}
		}

		public struct FamilyNode
		{
			public Family Family;
			public Dictionary<int, Genus> Genus;

			public FamilyNode(Family family, Dictionary<int, Genus> genus)
			{
				Family = family;
				Genus = genus;
			}
		}
	}
}
