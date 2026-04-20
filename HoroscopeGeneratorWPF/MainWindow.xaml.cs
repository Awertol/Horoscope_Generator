using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HoroscopeGeneratorWPF;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private List<string> pouzitaZnameni = new();
    private Dictionary<string, string> vygenerovaneHoroskopy = new();
    public MainWindow()
    {
        vygenerovaneHoroskopy.Add("Býk", "");
        vygenerovaneHoroskopy.Add("Kozorok", "");
        vygenerovaneHoroskopy.Add("Lev", "");
        vygenerovaneHoroskopy.Add("Blíženci", "");
        vygenerovaneHoroskopy.Add("Ryby", "");
        vygenerovaneHoroskopy.Add("Štír", "");
        vygenerovaneHoroskopy.Add("Beran", "");
        vygenerovaneHoroskopy.Add("Panna", "");
        vygenerovaneHoroskopy.Add("Váhy", "");
        vygenerovaneHoroskopy.Add("Vodnář", "");
        vygenerovaneHoroskopy.Add("Střelec", "");
        vygenerovaneHoroskopy.Add("Rak", "");
        InitializeComponent();
    }

    private void BtnGenerate_OnClick(object sender, RoutedEventArgs e)
    {
        string znameni = ZnameniSelection.Text;
        if (ZnameniSelection.SelectedValue == "" || ZnameniSelection.SelectedValue == String.Empty)
        {
            MessageBox.Show("Nejdříve vyberte své znamení, prosím.");
        }
        else if(pouzitaZnameni.Contains(znameni) == false)
        {
            string vygHoroskop = VygenerujHoroskop(znameni);
            HoroskopOutput.Text = vygHoroskop;
            pouzitaZnameni.Add(znameni);
            vygenerovaneHoroskopy[znameni] = vygHoroskop;
        }
        else if (pouzitaZnameni.Contains(znameni) == true)
        {
            HoroskopOutput.Text = vygenerovaneHoroskopy[znameni];
        }
    }

    private string VygenerujHoroskop(string znameni)
    {
        string subjekt = $"znamení {znameni}";

        string[] osobniZivot = new string[]
        {
            $"Osobní život: {subjekt} dnes může cítit, že se v něm mísí chuť něco změnit s potřebou zachovat jistotu. Právě tento vnitřní rozpor ale ukáže, co je skutečně důležité. Nebude nutné dělat velká rozhodnutí hned, mnohem víc pomůže dát si čas a sledovat, co se opakovaně vrací do myšlenek. Den přeje drobným krokům, které později vytvoří větší posun.",
            $"V osobním životě se dnes u {subjekt} mohou vracet témata, která působila jako uzavřená. Nepůjde o krok zpět, spíše o možnost podívat se na vše s větším nadhledem a zkušeností. To, co dříve působilo složitě, nyní může být překvapivě jasné. Pokud si {subjekt} dopřeje klidnější tempo, snadněji pozná, co si ponechat a co už nechat odejít.",
            $"Dnešní osobní život ukáže, že {subjekt} nemusí řešit všechno silou nebo okamžitou akcí. Někdy přichází nejlepší odpovědi ve chvíli, kdy člověk přestane tlačit na výsledek. Může se objevit příležitost srovnat si priority, udělat si pořádek v plánech a vrátit energii tam, kde dává největší smysl. Klid dnes bude větší výhodou než spěch.",
            $"Osobní rovina dnes přeje tomu, aby se {subjekt} více soustředilo na sebe a méně na očekávání okolí. Může si uvědomit, že některé věci vznikaly hlavně kvůli snaze vyhovět druhým. Tento poznatek nemusí přinést nepříjemnost, ale úlevu. Pokud si {subjekt} dovolí jednat přirozeněji, pocítí větší lehkost i jistotu v dalších dnech.",
            $"V osobním životě může mít dnes {subjekt} pocit, že se vše zpomaluje. To ale nemusí být překážka, spíše užitečný prostor k nadechnutí. Věci, které se nevyvíjejí podle představ, potřebují čas dozrát. Místo zbytečných obav bude lepší zaměřit se na to, co funguje už teď. Právě v obyčejných chvílích může {subjekt} najít největší klid.",
            $"Osobní život: {subjekt} dnes může překvapit vlastní reakcí na situaci, která by dříve vyvolala napětí. Ukáže se, že v poslední době nastal větší posun, než se zdálo. Není nutné hledat potvrzení zvenčí, protože změna bude patrná hlavně ve vnitřním pocitu stability. Den přeje sebedůvěře i laskavosti k sobě samému.",
            $"V osobním životě čeká {subjekt} den, kdy budou hrát roli drobnosti. Krátký rozhovor, náhoda nebo malá změna plánů může nasměrovat myšlenky novým směrem. Nebude třeba nic zásadního měnit, spíše si všímat signálů, které bývají snadno přehlédnutelné. Pokud zůstane {subjekt} otevřené novým podnětům, odnese si z dneška víc, než čekalo.",
            $"Osobní život dnes připomene, že {subjekt} nemusí mít odpověď na všechno. Některé věci se vyjasní až ve správný čas a tlak na okamžité řešení by jen zbytečně ubíral energii. Mnohem lepší bude věnovat pozornost tomu, co lze ovlivnit právě teď. Díky tomu získá {subjekt} pocit větší kontroly i vnitřního klidu.",
            $"V osobní oblasti může dnes {subjekt} pocítit silnější potřebu změny prostředí, rytmu nebo každodenních návyků. Nemusí jít o nic velkého, někdy stačí malý krok, aby se znovu probudila motivace. Den přeje novému pohledu na zaběhnuté věci. To, co vypadalo jednotvárně, může najednou nabídnout zajímavější možnosti.",
            $"Osobní život: {subjekt} dnes zjistí, že největší síla nemusí být v aktivitě, ale ve schopnosti správně vyčkat. Některé události se skládají ve prospěch budoucího výsledku, i když to zatím není vidět. Pokud si zachová trpělivost a nenechá se vyrušit cizím tempem, přijde pocit, že vše začíná dávat větší smysl."
        };

        string[] vztahy = new string[]
        {
            $"Ve vztazích dnes může {subjekt} vnímat citlivěji tón slov i náladu druhých. To, co bývá jindy přehlédnuto, nyní ukáže důležité souvislosti. Pokud se vyhne unáhleným závěrům, snadno pozná, kdo to myslí upřímně. Den přeje otevřené komunikaci, ale také schopnosti nebrat si vše osobně. Právě vyrovnanost přinese největší harmonii.",
            $"Vztahy dnes povedou {subjekt} k uvědomění, že někdy stačí méně vysvětlovat a více naslouchat. Druhá strana nemusí hledat radu, ale pochopení. I běžný rozhovor může mít větší hloubku, než se na první pohled zdá. Pokud bude {subjekt} jednat přirozeně a bez potřeby vše řídit, atmosféra kolem něj se znatelně uvolní.",
            $"Na poli vztahů může dnes {subjekt} pocítit potřebu udělat si jasno v tom, komu věnuje svou energii. Ne každý kontakt je stejně vyrovnaný a dnešní den to může zřetelně ukázat. Není nutné nic dramaticky ukončovat, spíše nastavit zdravější hranice. Díky tomu si {subjekt} zachová klid a více prostoru pro lidi, kteří dávají opravdovou hodnotu.",
            $"Ve vztazích bude dnes {subjekt} působit silněji, než si myslí. Slova i gesta mohou mít větší dopad, proto se vyplatí volit je vědomě. Dobře míněná upřímnost může pomoci, pokud bude podaná citlivě. Den přeje smíření, obnovení důvěry i příjemným setkáním, která připomenou význam blízkosti.",
            $"Vztahová oblast dnes ukáže {subjekt}, že některé nejasnosti vznikly spíše z domněnek než ze skutečnosti. Místo tichého přemýšlení bude lepší zeptat se přímo a bez napětí. Odpověď může být jednodušší, než se zdálo. Pokud se {subjekt} otevře přímé komunikaci, mnoho věcí se rychle vrátí do rovnováhy.",
            $"Ve vztazích může dnes {subjekt} překvapit vlastní potřeba většího klidu a odstupu. Nepůjde o chlad, ale o přirozenou potřebu srovnat si pocity. Druhým pomůže, když to pochopí jako součást dnešního naladění, ne jako odmítnutí. Jakmile si {subjekt} dopřeje prostor, vrátí se do kontaktu s větší lehkostí a jistotou.",
            $"Vztahy: {subjekt} dnes může zažít chvíli, která připomene význam lidí, na které je spoleh. Nemusí jít o velké gesto, někdy stačí obyčejný zájem nebo krátká zpráva ve správný čas. Den podporuje vděčnost i uvědomění, že pevné vazby se tvoří dlouhodobě. To, co je stabilní, bude dnes působit ještě cenněji.",
            $"V oblasti vztahů dnes bude pro {subjekt} důležité rozlišit, co je vlastní pocit a co nálada převzatá od okolí. Citlivější atmosféra může svádět k přehnaným reakcím, ale stačí malé zpomalení a vše se ukáže jasněji. Pokud zůstane {subjekt} v klidu, zvládne i náročnější komunikaci s přehledem a bez zbytečných sporů.",
            $"Ve vztazích dnes může {subjekt} zjistit, že někdo čeká na jeho iniciativu. To, co se zdálo jako nezájem, může být jen opatrnost nebo nejistota. Vyplatí se udělat první krok, ozvat se nebo projevit vstřícnost. I drobný impuls může obnovit kontakt, který měl větší význam, než se zdálo.",
            $"Partnerské i přátelské vazby dnes povedou {subjekt} k větší upřímnosti vůči sobě samému. Může se ukázat, co chybí, co naopak prospívá a kde už není vhodné dělat kompromisy. Takové poznání nemusí nic narušit, spíše pomůže nastavit zdravější směr. Díky tomu budou další vztahové kroky jistější a přirozenější."
        };

        string[] penize = new string[]
        {
            $"Po stránce peněz dnes může {subjekt} zjistit, že nejlepší rozhodnutí nevznikají pod tlakem, ale s odstupem. Pokud se objeví nabídka nebo chuť něco rychle řešit, vyplatí se nejprve ověřit detaily. Den přeje rozumnému plánování, menším úpravám rozpočtu a krokům, které nejsou nápadné, ale dlouhodobě fungují. Stabilita bude mít větší cenu než risk.",
            $"Peníze dnes povedou {subjekt} k větší praktičnosti. To, co bylo dříve odkládáno, může být vhodné konečně srovnat a uzavřít. Nemusí jít jen o výdaje, ale i o nový přístup k hospodaření s časem a energií. Pokud se {subjekt} zaměří na skutečné priority, pocítí větší jistotu a menší tlak do dalších dnů.",
            $"Ve finanční oblasti může dnes {subjekt} pocítit potřebu mít věci více pod kontrolou. Tento impuls je užitečný, pokud nepřeroste v zbytečné obavy. Stačí podívat se realisticky na současnou situaci a udělat jeden konkrétní krok správným směrem. I malá změna návyků může přinést větší efekt, než se na první pohled zdá.",
            $"Po stránce peněz bude dnes pro {subjekt} důležité rozlišit mezi tím, co láká hned, a tím, co bude výhodné později. Krátkodobé uspokojení může svádět, ale trpělivější přístup přinese lepší výsledek. Den přeje rozvaze, promyšleným nákupům a rozhodnutím, která posílí pocit bezpečí do budoucna.",
            $"Peníze: {subjekt} dnes může narazit na inspiraci, jak si usnadnit každodenní fungování nebo lépe využít své zdroje. Nemusí jít přímo o vyšší příjem, ale o chytřejší systém. Někdy je největším ziskem méně chaosu a více přehledu. Pokud se otevře novému způsobu uvažování, rychle pozná jeho přínos.",
            $"Finanční energie dne přeje tomu, aby {subjekt} nepodceňovalo drobnosti. Menší částky, pravidelné výdaje nebo opakující se návyky mohou mít větší vliv, než se zdá. Dnes je vhodná chvíle všimnout si detailů, které dříve unikaly. Právě tam může vzniknout prostor pro zlepšení i větší rezervu.",
            $"Po stránce peněz dnes může {subjekt} získat větší klid díky tomu, že si přestane vytvářet zbytečné scénáře. Ne vše je tak naléhavé, jak se může zdát v hlavě. Realita bude pravděpodobně příznivější, než napovídají obavy. Pokud zůstane u faktů a jednoduchých kroků, situace se bude vyvíjet stabilněji.",
            $"Peníze dnes připomenou {subjekt}, že hodnota není jen v číslech, ale i v tom, kam proudí energie. Výdaje spojené s pohodou, zdravím nebo rozvojem mohou mít větší smysl než věci kupované ze zvyku. Den přeje vědomějším rozhodnutím a lepšímu pocitu z toho, jak jsou prostředky využívány.",
            $"Ve finančních záležitostech dnes může {subjekt} pocítit, že nastal čas něco přehodnotit. To, co fungovalo dříve, nemusí být nejlepší i nyní. Nemusí jít o velkou změnu, někdy stačí upravit priority nebo způsob plánování. Výsledkem může být větší svoboda a menší pocit omezení.",
            $"Po stránce peněz bude mít dnes {subjekt} výhodu v trpělivosti. Některé výsledky nepřijdou okamžitě, ale postupně se skládají ve prospěch budoucnosti. Pokud se nenechá rozhodit srovnáváním s ostatními a zůstane u svého tempa, zjistí, že jde správným směrem. Důvěra ve vlastní plán bude dnes cennější než rychlé zkratky."
        };

        string odstavec1 = osobniZivot[Random.Shared.Next(osobniZivot.Length)];
        string odstavec2 = vztahy[Random.Shared.Next(vztahy.Length)];
        string odstavec3 = penize[Random.Shared.Next(penize.Length)];

        string horoskop = odstavec1 + "\n \n"+
                          odstavec2 + "\n \n" +
                          odstavec3;
        return horoskop;
    }
}