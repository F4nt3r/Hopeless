using HopelessLibary;

namespace Hopeless
{
    public partial class Form1 : Form
    {
        private MenuUserControl menuUserControl;
        private PrzygotowanieUserControl fazaPrzygotowaniaUserControl;
        private WyprawaUserControl wyprawaUserControl;
        private List<Character> characters;
        public Form1()
        {
            InitializeComponent();

            // Inicjalizacja UserControl
            menuUserControl = new MenuUserControl();
            fazaPrzygotowaniaUserControl = new PrzygotowanieUserControl();
            wyprawaUserControl = new WyprawaUserControl();
            Controls.Add(menuUserControl);
            Controls.Add(fazaPrzygotowaniaUserControl);
            Controls.Add(wyprawaUserControl);

            // Inicjalizacja postaci
            Knight knight = new Knight("Lancelot",0,10,5,2,50,50,50,10,34,1,2,33);
            Rogue rogue = new Rogue("Astarion",0,2,10,5,35,35,30,50,70,1,2,33);
            Cleric cleric = new Cleric("Melitele",0,2,5,10,45,45,40,30,30,1,2);
            Joker joker = new Joker("Jaskier",0,2,7,8,30,30,30,50,50,1,2);
            characters = new List<Character> { knight,rogue,cleric,joker };
            fazaPrzygotowaniaUserControl.Characters = characters;

            // Inicjalizacja broni
            Weapon sword = new Weapon("Miecz Stalowy", "Opis Miecza", 5, 12,new List<Character> {knight});
            Weapon axe = new Weapon("Topor Bojowy", "Opis Topora", 8, 13, new List<Character> { knight });
            Weapon gun = new Weapon("Pistolet Skalkowy", "Opis Pistoletu", 5, 12, new List<Character> { rogue });
            
            // Inicjalizacja armora
            Armor armour = new Armor("Ciezka Zbroja", "Opis Zbroi",12, new List<Character> { knight });
            Armor lightweightarmour = new Armor("Lekka Zbroja", "Opis Zbroi", 5, new List<Character> { rogue,cleric,joker });

            List<IEkwipunek> ekwipunek = new List<IEkwipunek> { sword, gun, armour, axe, lightweightarmour };
            fazaPrzygotowaniaUserControl.Ekwipunek = ekwipunek;

            // Dodanie UserControl do Form1




            // Ustawienie pocz¹tkowej widocznoœci UserControl
            menuUserControl.Visible = true;
            fazaPrzygotowaniaUserControl.Visible = false;
            wyprawaUserControl.Visible = false;

           
            menuUserControl.NowaGraButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Visible = true;
                menuUserControl.Visible = false;
            };

            fazaPrzygotowaniaUserControl.WyruszButtonClicked += (sender, args) =>
            {
                fazaPrzygotowaniaUserControl.Visible = false;
                wyprawaUserControl.Visible = true;
            };
        }

    }
}