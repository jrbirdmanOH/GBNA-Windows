using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Thayer.Birding.UI.Windows.Quiz
{
	public partial class MyQuizQuickStartForm : BaseForm
	{
		public MyQuizQuickStartForm()
		{
			InitializeComponent();
			this.SettingsKey = this.Name;
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			// Restore user setting
			showQuickStartCheckBox.Checked = UserSettings.Instance.ShowCustomQuizQuickStart;

			// Set content of RichTextBox
			StringBuilder rtf = new StringBuilder();
			rtf.Append(@"{\rtf1\adeflang1025\ansi\ansicpg1252\uc1\adeff0\deff0\stshfdbch37\stshfloch37\stshfhich37\stshfbi0\deflang1033\deflangfe1033{\fonttbl{\f0\froman\fcharset0\fprq2{\*\panose 02020603050405020304}Times New Roman;}{\f1\fswiss\fcharset0\fprq2{\*\panose 020b0604020202020204}Arial;}
{\f37\fswiss\fcharset0\fprq2{\*\panose 020f0502020204030204}Calibri;}{\f289\froman\fcharset238\fprq2 Times New Roman CE;}{\f290\froman\fcharset204\fprq2 Times New Roman Cyr;}{\f292\froman\fcharset161\fprq2 Times New Roman Greek;}
{\f293\froman\fcharset162\fprq2 Times New Roman Tur;}{\f294\fbidi \froman\fcharset177\fprq2 Times New Roman (Hebrew);}{\f295\fbidi \froman\fcharset178\fprq2 Times New Roman (Arabic);}{\f296\froman\fcharset186\fprq2 Times New Roman Baltic;}
{\f297\froman\fcharset163\fprq2 Times New Roman (Vietnamese);}{\f299\fswiss\fcharset238\fprq2 Arial CE;}{\f300\fswiss\fcharset204\fprq2 Arial Cyr;}{\f302\fswiss\fcharset161\fprq2 Arial Greek;}{\f303\fswiss\fcharset162\fprq2 Arial Tur;}
{\f304\fbidi \fswiss\fcharset177\fprq2 Arial (Hebrew);}{\f305\fbidi \fswiss\fcharset178\fprq2 Arial (Arabic);}{\f306\fswiss\fcharset186\fprq2 Arial Baltic;}{\f307\fswiss\fcharset163\fprq2 Arial (Vietnamese);}{\f659\fswiss\fcharset238\fprq2 Calibri CE;}
{\f660\fswiss\fcharset204\fprq2 Calibri Cyr;}{\f662\fswiss\fcharset161\fprq2 Calibri Greek;}{\f663\fswiss\fcharset162\fprq2 Calibri Tur;}{\f666\fswiss\fcharset186\fprq2 Calibri Baltic;}}{\colortbl;\red0\green0\blue0;\red0\green0\blue255;
\red0\green255\blue255;\red0\green255\blue0;\red255\green0\blue255;\red255\green0\blue0;\red255\green255\blue0;\red255\green255\blue255;\red0\green0\blue128;\red0\green128\blue128;\red0\green128\blue0;\red128\green0\blue128;\red128\green0\blue0;
\red128\green128\blue0;\red128\green128\blue128;\red192\green192\blue192;}{\stylesheet{\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \rtlch\fcs1 \af0\afs22\alang1025 \ltrch\fcs0 
\fs22\lang1033\langfe1033\loch\f37\hich\af37\dbch\af37\cgrid\langnp1033\langfenp1033 \snext0 \styrsid8999901 Normal;}{\*\cs10 \additive \ssemihidden Default Paragraph Font;}{\*
\ts11\tsrowd\trftsWidthB3\trpaddl108\trpaddr108\trpaddfl3\trpaddft3\trpaddfb3\trpaddfr3\trcbpat1\trcfpat1\tblind0\tblindtype3\tscellwidthfts0\tsvertalt\tsbrdrt\tsbrdrl\tsbrdrb\tsbrdrr\tsbrdrdgl\tsbrdrdgr\tsbrdrh\tsbrdrv 
\ql \li0\ri0\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0 \rtlch\fcs1 \af0\afs20 \ltrch\fcs0 \fs20\lang1024\langfe1024\loch\f37\hich\af37\dbch\af37\cgrid\langnp1024\langfenp1024 \snext11 \ssemihidden Normal Table;}{
\s15\ql \li720\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin720\itap0\contextualspace \rtlch\fcs1 \af0\afs22\alang1025 \ltrch\fcs0 
\fs22\lang1033\langfe1033\loch\f37\hich\af37\dbch\af37\cgrid\langnp1033\langfenp1033 \sbasedon0 \snext15 \styrsid6884702 List Paragraph;}{\*\cs16 \additive \rtlch\fcs1 \af0 \ltrch\fcs0 \ul\cf2 \sbasedon10 \styrsid16659618 Hyperlink;}}
{\*\latentstyles\lsdstimax156\lsdlockeddef0}{\*\rsidtbl \rsid229047\rsid414515\rsid727896\rsid1915336\rsid2038822\rsid2050781\rsid2113672\rsid2308303\rsid2699167\rsid2908790\rsid3371791\rsid3411286\rsid3474059\rsid3748340\rsid4538641\rsid5046852
\rsid5524654\rsid6884702\rsid7681907\rsid8080315\rsid8327116\rsid8355658\rsid8552091\rsid8612349\rsid8999901\rsid9525293\rsid9708112\rsid11212778\rsid11296801\rsid11355041\rsid11362874\rsid12854418\rsid12856688\rsid13057318\rsid13189774\rsid13313090
\rsid13778284\rsid15415746\rsid15488405\rsid15950731\rsid16132132\rsid16458098\rsid16649460\rsid16659618}{\*\generator Microsoft Word 11.0.0000;}{\info{\title Now you can create your own quiz on any topic}{\author Pete}{\operator Lightship}
{\creatim\yr2008\mo9\dy24\hr15\min29}{\revtim\yr2008\mo9\dy24\hr16\min41}{\version9}{\edmins79}{\nofpages2}{\nofwords711}{\nofchars4055}{\nofcharsws4757}{\vern24613}{\*\password 00000000}}{\*\xmlnstbl {\xmlns1 http://schemas.microsoft.com/office/word/2003
/wordml}{\xmlns2 urn:schemas-microsoft-com:office:smarttags}}\paperw12240\paperh15840\margl1440\margr1440\margt1440\margb1440\gutter0\ltrsect 
\widowctrl\ftnbj\aenddoc\donotembedsysfont1\donotembedlingdata0\grfdocevents0\validatexml1\showplaceholdtext0\ignoremixedcontent0\saveinvalidxml0\showxmlerrors1\noxlattoyen\expshrtn\noultrlspc\dntblnsbdb\nospaceforul\formshade\horzdoc\dgmargin\dghspace180
\dgvspace180\dghorigin1440\dgvorigin1440\dghshow1\dgvshow1
\jexpand\viewkind4\viewscale100\pgbrdrhead\pgbrdrfoot\splytwnine\ftnlytwnine\htmautsp\nolnhtadjtbl\useltbaln\alntblind\lytcalctblwd\lyttblrtgr\lnbrkrule\nobrkwrptbl\snaptogridincell\allowfieldendsel\wrppunct
\asianbrkrule\rsidroot15415746\newtblstyruls\nogrowautofit \fet0{\*\wgrffmtfilter 2450}\ilfomacatclnup0\ltrpar \sectd \ltrsect\linex0\endnhere\sectlinegrid360\sectdefaultcl\sectrsid8999901\sftnbj {\*\pnseclvl1\pnucrm\pnstart1\pnindent720\pnhang 
{\pntxta .}}{\*\pnseclvl2\pnucltr\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl3\pndec\pnstart1\pnindent720\pnhang {\pntxta .}}{\*\pnseclvl4\pnlcltr\pnstart1\pnindent720\pnhang {\pntxta )}}{\*\pnseclvl5\pndec\pnstart1\pnindent720\pnhang {\pntxtb (}
{\pntxta )}}{\*\pnseclvl6\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl7\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl8\pnlcltr\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}{\*\pnseclvl9
\pnlcrm\pnstart1\pnindent720\pnhang {\pntxtb (}{\pntxta )}}\pard\plain \ltrpar\ql \li0\ri0\sb240\sa120\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid3411286 \rtlch\fcs1 \af0\afs22\alang1025 \ltrch\fcs0 
\fs22\lang1033\langfe1033\loch\af37\hich\af37\dbch\af37\cgrid\langnp1033\langfenp1033 {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Now you can create your own quiz on any topic!}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13057318 
\par }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid15415746 {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13778284\charrsid16132132 \hich\af1\dbch\af37\loch\f1 You will s}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 tart by creating a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1  (like Butterflies, Wildflowers or Birds). Then add }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item
}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s to the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 . For example, Monarch Butterfly might be an }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1  you want to add to your Butterfly }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 . Each\hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1  you add must include a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8552091\charrsid16132132 \hich\af1\dbch\af37\loch\f1 name and a }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 photo. You }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 may}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1  include }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8552091\charrsid16132132 \hich\af1\dbch\af37\loch\f1 a sound and }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 an alternate photo as well. You may also include an alternate name}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8552091\charrsid16132132 \hich\af1\dbch\af37\loch\f1  (}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 such \hich\af1\dbch\af37\loch\f1 as }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \i\f1\fs20\cf1\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
Danaus plexippus\hich\af1\dbch\af37\loch\f1 , }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 the scientific name for Monarch }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\cf1\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 B}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 utte\hich\af1\dbch\af37\loch\f1 r\hich\af1\dbch\af37\loch\f1 fly}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid8552091\charrsid16132132 \hich\af1\dbch\af37\loch\f1 )}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 .\hich\af1\dbch\af37\loch\f1  }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid12856688\charrsid16132132 
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Next }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 you will }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid13189774\charrsid16132132 \hich\af1\dbch\af37\loch\f1 create quizzes}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  within each }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 C\hich\af1\dbch\af37\loch\f1 ategory}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid11355041\charrsid16132132 \hich\af1\dbch\af37\loch\f1  --}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  Butterflies of Texas and Butterflies of Florida could both be quizzes in the Butterfly }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\cf1\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 . Finally, }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\cf1\insrsid8612349\charrsid16132132 \hich\af1\dbch\af37\loch\f1 create Quiz Questions}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1  by selecting the }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\cf1\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 I}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\cf1\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 tems }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\cf1\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 you want to appear in each quiz. In this case, we}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  would simply }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 move}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  \hich\af1\dbch\af37\loch\f1 
Monarch Butterfly\hich\af1\dbch\af37\loch\f1  into the\hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 list of questions for the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Butterflies of Florida\hich\af1\dbch\af37\loch\f1  quiz and it would become one of the \hich\af1\dbch\af37\loch\f1 butterflies\hich\af1\dbch\af37\loch\f1  we }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 are quizzed on }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 when taking that quiz. The same }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  can be added to }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 more than one}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  quiz.
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13778284\charrsid16132132 \hich\af1\dbch\af37\loch\f1 OK, let\hich\f1 \rquote \loch\f1 s begin. }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 Start by clicking the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Quizzes icon}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  and then click \hich\af1\dbch\af37\loch\f1 the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Manage My Quizzes}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\b\f1\fs20\insrsid2038822\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12856688\charrsid16132132 \hich\af1\dbch\af37\loch\f1  button at the bottom of the screen.}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\cf1\insrsid12856688\charrsid16132132 
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid12854418\charrsid16132132 \hich\af1\dbch\af37\loch\f1 1. }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Create a }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \b\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  from the Manage My Quizzes screen}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid11355041\charrsid16132132 \hich\af1\dbch\af37\loch\f1 :\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 select the File->New->}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  menu }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid11355041\charrsid16132132 \hich\af1\dbch\af37\loch\f1 \hich\f1  \'85\loch\f1  or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  click the New toolbar button and select the New }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  menu option}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid11355041\charrsid16132132 \hich\af1\dbch\af37\loch\f1 \hich\f1  \'85}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  or }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid11355041\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1       }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 ri\hich\af1\dbch\af37\loch\f1 ght-click}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid11355041\charrsid16132132 \hich\af1\dbch\af37\loch\f1  anywhere on the screen}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  and select New->}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  from the context menu.
\par }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid7681907 {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Think of a }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1  as a container for holding all }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2908790\charrsid16132132 \hich\af1\dbch\af37\loch\f1 of }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 th}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 at}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \rquote \loch\f1 s}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
s. You may have 500 different butterfl}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 y species}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  as }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
s within the Butterfly }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
. Any one of th\hich\af1\dbch\af37\loch\f1 ese 500 }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 s could show up as a possible answer in the quizzes you create within that }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 . It is important that you plan your categories carefully before creating }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s. Butterflies may be a great }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1  for some folks, but others may want Butterfl\hich\af1\dbch\af37\loch\f1 
ies of South America and Butterflies of North America as two separate categories so that a South American butterfly does not appear as a possible answer in a North American butterfly quiz.
\par }\pard \ltrpar\ql \li0\ri0\sa200\sl276\slmult1\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid15415746 {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid12854418\charrsid16132132 \hich\af1\dbch\af37\loch\f1 2. }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid7681907\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Once you have created a }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid12854418\charrsid16132132 \hich\af1\dbch\af37\loch\f1 , c}{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 reate }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12854418\charrsid16132132 \hich\af1\dbch\af37\loch\f1 :\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  \hich\af1\dbch\af37\loch\f1 click the }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid5046852\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'93}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Create and Add }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid5046852\charrsid16132132 \hich\af1\dbch\af37\loch\f1 .}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 ..}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid5046852\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'94}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  button when creating a new }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12854418\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85\loch\f1 or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  highlight a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  and select the File->Edit menu }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid12854418\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85\loch\f1 or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  highlight a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  and click the Edit toolbar button}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid12854418\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  or }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid12854418\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1       }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 right-click a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  and select the Edit \hich\af1\dbch\af37\loch\f1 menu }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 .
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s are }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 \hich\f1 the \'93}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3474059\charrsid16132132 \hich\af1\dbch\af37\loch\f1 questions}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'94\loch\f1  that will appear in your quizzes. }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2908790\charrsid16132132 \hich\af1\dbch\af37\loch\f1 \hich\f1 Click the New\'85
\loch\f1  button to add a new Category item. }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 When creating }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}
{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s, keep in mind that they }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 will}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  be shared among all quizzes in the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 .  Also, note that when e\hich\af1\dbch\af37\loch\f1 diting/deleting }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 , all quiz questions that reference th}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 at}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  will also be edited/deleted.}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9708112\charrsid16132132 \hich\af1\dbch\af37\loch\f1 You will need a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 name and a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9708112\charrsid16132132 \hich\af1\dbch\af37\loch\f1 photo for each Category }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9708112\charrsid16132132 \hich\af1\dbch\af37\loch\f1 . }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 In the introduction we}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9708112\charrsid16132132 \hich\af1\dbch\af37\loch\f1  used Monarch Butterfly as an example of a Category }{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9708112\charrsid16132132 \hich\af1\dbch\af37\loch\f1 . But}{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1  \hich\af1\dbch\af37\loch\f1 if your Category is {\*\xmlopen\xmlns2{\factoidname place}}{\*\xmlopen\xmlns2{\factoidname country-region}}U.S.{\*\xmlclose}{\*\xmlclose}
 Presidents, a Category }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
 might be George Washington.\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 3. Create }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 a }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 quiz}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 :}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid2113672\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1     }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  highlight a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  and select}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1  the}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  File->New->Quiz menu }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 
\loch\af1\dbch\af37\hich\f1 \'85\loch\f1 or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 highlight a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  and click the New toolbar button and select the New Quiz men\hich\af1\dbch\af37\loch\f1 u option}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  or }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 right-click on a }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  and selecting the New->Quiz menu option.
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2308303\charrsid16132132 \hich\af1\dbch\af37\loch\f1 For each Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
 you may create an unlimited number of quizzes. For example, you}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2308303\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
 might create quizzes based on regions of the country. Or you may want quizzes based on c\hich\af1\dbch\af37\loch\f1 olor or size or habitat.  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'93
\loch\f1 My }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Quizzes}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'94}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  can be run just like any other quiz in th}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 is program}{
\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 .  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
Click the My Quizzes tab to see the quizzes you made. 
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 4. Add questions to }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 a }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 quiz}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 :}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid2113672\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid727896\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 click the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'93}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
Create and Add Questions...}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'94}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
 button when creating a new quiz}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85\loch\f1 or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid727896\charrsid16132132 
\hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 highlight a quiz and select the File->Edit menu }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85\loch\f1 or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid727896\charrsid16132132 \hich\af1\dbch\af37\loch\f1      }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 highlight a quiz and clicking the Edit toolbar button}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \loch\af1\dbch\af37\hich\f1 \'85\loch\f1 or\line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid727896\charrsid16132132 \hich\af1\dbch\af37\loch\f1     }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  right-click a quiz and selecting the Edit menu }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 .
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1 If you want a Category }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1  to appear as a}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid727896\charrsid16132132 \hich\af1\dbch\af37\loch\f1  question}{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1  in your quiz, highlight\hich\af1\dbch\af37\loch\f1  a Category }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item
}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1  on the right and click the arrow to move it into the }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8355658\charrsid16132132 
\hich\af1\dbch\af37\loch\f1 Questions}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1  on the left. }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8355658\charrsid16132132 \line }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 5. Run }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 a }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \b\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 quiz}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid2113672\charrsid16132132 \hich\af1\dbch\af37\loch\f1 :}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid2113672\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1 All your new quizzes}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 
\hich\af1\dbch\af37\loch\f1  can }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid3371791\charrsid16132132 \hich\af1\dbch\af37\loch\f1 now }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
be run by starting the Quiz Wizard and clicking the My Quizzes tab when asked to select a quiz source.  
\par \hich\af1\dbch\af37\loch\f1 Once you hav\hich\af1\dbch\af37\loch\f1 e selected a quiz}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
 click Next>> and select a quiz type. You may take any type of quiz: Multiple Choice, Fill-in-the-blank, Flash Card or Pick One.}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8355658\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 
\af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid9525293\charrsid16132132 \hich\af1\dbch\af37\loch\f1 C}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 ontinue by }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8355658\charrsid16132132 \hich\af1\dbch\af37\loch\f1 clicking Next>> and }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
providing quiz settings that are appropriate for the type of data you supplied\hich\af1\dbch\af37\loch\f1  for your }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s.  For example, do not choose the Sound media type option if you have not specified sound files for most of your }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid229047\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Category}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1  }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8327116\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Item}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15415746\charrsid16132132 \hich\af1\dbch\af37\loch\f1 s.  Continue through the quiz wizard and }{\rtlch\fcs1 \af1\afs20 
\ltrch\fcs0 \f1\fs20\insrsid8355658\charrsid16132132 \hich\af1\dbch\af37\loch\f1 click the Run Quiz button to take a quiz.}{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid15488405\charrsid16132132 \line }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 
\f1\fs20\insrsid8999901\charrsid16132132 
\par }\pard \ltrpar\ql \li0\ri0\sa120\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid3748340 {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \b\f1\fs20\insrsid16659618\charrsid16132132 \hich\af1\dbch\af37\loch\f1 Watch a Video Tutorial
\hich\af1\dbch\af37\loch\f1  about creating My Quizzes.
\par }\pard \ltrpar\ql \li0\ri0\sa200\widctlpar\wrapdefault\aspalpha\aspnum\faauto\adjustright\rin0\lin0\itap0\pararsid3748340 {\field\fldedit{\*\fldinst {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid13313090\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
HYPERLINK http://www.thayerbirdingtest.com/gbna/WebLinks.asp?r=TUTORIAL}}{\fldrslt {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \cs16\f1\fs20\ul\cf2\insrsid16659618\charrsid16132132 \hich\af1\dbch\af37\loch\f1 
http://www.thayerbirding.com/gbna/WebLinks.asp?r=TUTORIAL}}}\sectd \linex0\endnhere\sectlinegrid360\sectdefaultcl\sectrsid8999901\sftnbj {\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid16659618 
\par }{\rtlch\fcs1 \af1\afs20 \ltrch\fcs0 \f1\fs20\insrsid11362874\charrsid16132132 
\par }}");
			richTextBox.Rtf = rtf.ToString();

			// Set background colors of controls
			panel.BackColor = System.Drawing.SystemColors.Window;
			richTextBox.BackColor = System.Drawing.SystemColors.Window;

			// Set focus to the RichTextBox
			richTextBox.Focus();
		}

		private void MyQuizQuickStartForm_FormClosing(object sender, FormClosingEventArgs e)
		{
			UserSettings.Instance.ShowCustomQuizQuickStart = showQuickStartCheckBox.Checked;
		}

		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void richTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
		{
			Utility.ShowWebBrowser(e.LinkText);
		}
	}
}