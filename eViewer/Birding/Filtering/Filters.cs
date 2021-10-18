using System;
using System.Collections.Generic;
using System.Text;
using Thayer.Birding.Licensing;

namespace Thayer.Birding.Filtering
{
	public class Filters
	{
		private static Filters instance = new Filters();

		private FilterCollection familyFilters = new FilterCollection();
		private FilterCollection usFilters = new FilterCollection();
		private FilterCollection canadaFilters = new FilterCollection();
		private FilterCollection regionFilters = new FilterCollection();

		private Filters()
		{
			CreateCanadaFilters();
			CreateUSFilters();
			CreateRegionFilters();
			CreateFamilyFilters();
		}

		public static Filters Instance
		{
			get
			{
				return instance;
			}
		}

		public FilterCollection CanadaFilters
		{
			get
			{
				return canadaFilters;
			}
		}

		public FilterCollection UnitedStatesFilters
		{
			get
			{
				return usFilters;
			}
		}

		public FilterCollection RegionFilters
		{
			get
			{
				return regionFilters;
			}
		}

		public FilterCollection FamilyFilters
		{
			get
			{
				return familyFilters;
			}
		}

		private void CreateCanadaFilters()
		{
			canadaFilters = new FilterCollection();
			canadaFilters.FilterType = FilterCollection.FilterTypes.Province;

			canadaFilters.Add(new StateFilter(337, "Alberta"));
			canadaFilters.Add(new StateFilter(338, "British Columbia"));
			canadaFilters.Add(new StateFilter(339, "Manitoba"));
			canadaFilters.Add(new StateFilter(340, "New Brunswick"));
			canadaFilters.Add(new StateFilter(341, "Newfoundland"));
			canadaFilters.Add(new StateFilter(342, "Northwest Territories"));
			canadaFilters.Add(new StateFilter(343, "Nova Scotia"));
			canadaFilters.Add(new StateFilter(782, "Nunavut"));
			canadaFilters.Add(new StateFilter(344, "Ontario"));
			canadaFilters.Add(new StateFilter(345, "Price Edward Island"));
			canadaFilters.Add(new StateFilter(346, "Quebec"));
			canadaFilters.Add(new StateFilter(347, "Saskatchewan"));
			canadaFilters.Add(new StateFilter(348, "Yukon Territory"));
		}

		private void CreateUSFilters()
		{
			usFilters = new FilterCollection();
			usFilters.FilterType = FilterCollection.FilterTypes.State;

			usFilters.Add(new StateFilter(405, "Alabama"));
			usFilters.Add(new StateFilter(406, "Alaska"));
			usFilters.Add(new StateFilter(407, "Arizona"));
			usFilters.Add(new StateFilter(415, "Arkansas"));
			usFilters.Add(new StateFilter(416, "California"));
			usFilters.Add(new StateFilter(417, "Colorado"));
			usFilters.Add(new StateFilter(482, "Connecticut"));
			usFilters.Add(new StateFilter(483, "Delaware"));
			usFilters.Add(new StateFilter(484, "District of Columbia"));
			usFilters.Add(new StateFilter(485, "Florida"));
			usFilters.Add(new StateFilter(488, "Georgia"));
//			usFilters.Add(new StateFilter(489, "Hawaii"));
			usFilters.Add(new StateFilter(490, "Idaho"));
			usFilters.Add(new StateFilter(491, "Illinois"));
			usFilters.Add(new StateFilter(492, "Indiana"));
			usFilters.Add(new StateFilter(493, "Iowa"));
			usFilters.Add(new StateFilter(494, "Kansas"));
			usFilters.Add(new StateFilter(495, "Kentucky"));
			usFilters.Add(new StateFilter(496, "Louisiana"));
			usFilters.Add(new StateFilter(497, "Maine"));
			usFilters.Add(new StateFilter(498, "Maryland"));
			usFilters.Add(new StateFilter(499, "Massachusetts"));
			usFilters.Add(new StateFilter(500, "Michigan"));
			usFilters.Add(new StateFilter(501, "Minnesota"));
			usFilters.Add(new StateFilter(502, "Mississippi"));
			usFilters.Add(new StateFilter(503, "Missouri"));
			usFilters.Add(new StateFilter(504, "Montana"));
			usFilters.Add(new StateFilter(505, "Nebraska"));
			usFilters.Add(new StateFilter(506, "Nevada"));
			usFilters.Add(new StateFilter(507, "New Hampshire"));
			usFilters.Add(new StateFilter(508, "New Jersey"));
			usFilters.Add(new StateFilter(509, "New Mexico"));
			usFilters.Add(new StateFilter(510, "New York"));
			usFilters.Add(new StateFilter(511, "North Carolina"));
			usFilters.Add(new StateFilter(512, "North Dakota"));
			usFilters.Add(new StateFilter(513, "Ohio"));
			usFilters.Add(new StateFilter(514, "Oklahoma"));
			usFilters.Add(new StateFilter(515, "Oregon"));
			usFilters.Add(new StateFilter(516, "Pennsylvania"));
			usFilters.Add(new StateFilter(517, "Rhode Island"));
			usFilters.Add(new StateFilter(518, "South Carolina"));
			usFilters.Add(new StateFilter(519, "South Dakota"));
			usFilters.Add(new StateFilter(520, "Tennessee"));
			usFilters.Add(new StateFilter(523, "Texas"));
			usFilters.Add(new StateFilter(524, "Utah"));
			usFilters.Add(new StateFilter(525, "Vermont"));
			usFilters.Add(new StateFilter(526, "Virginia"));
			usFilters.Add(new StateFilter(527, "Washington"));
			usFilters.Add(new StateFilter(528, "West Virginia"));
			usFilters.Add(new StateFilter(529, "Wisconsin"));
			usFilters.Add(new StateFilter(530, "Wyoming"));
		}

		private void CreateRegionFilters()
		{
			regionFilters = new FilterCollection();
			regionFilters.FilterType = FilterCollection.FilterTypes.Region;

			List<Product> regionProducts = Product.RegionProductList;

			foreach (Product product in regionProducts)
			{
				regionFilters.Add(new RegionFilter(product.Collection.ID, product.Name));
			}
		}

		private void CreateFamilyFilters()
		{
			List<Family> families = Family.GetList();

			familyFilters = new FilterCollection();
			familyFilters.FilterType = FilterCollection.FilterTypes.Family;
			foreach (Family family in families)
			{
				familyFilters.Add(new FamilyFilter(family.ID, family.Description));
			}
		}

		public FilterCollection GetCustomListFilters(int collectionID)
		{
			FilterCollection customListFilters = new FilterCollection();
			customListFilters.FilterType = FilterCollection.FilterTypes.CustomList;

			List<CustomList> customLists = CustomList.GetList(collectionID);
			foreach(CustomList customList in customLists)
			{
				customListFilters.Add(new CustomListFilter(customList.ID, customList.Name, customList.ToString()));
			}

			return customListFilters;
		}
	}
}
