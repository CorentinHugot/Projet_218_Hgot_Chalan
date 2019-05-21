using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Présentation des règles du jeu :

            Console.WriteLine("");
            Console.WriteLine("     ██████╗ ██╗███████╗███╗   ██╗██╗   ██╗███████╗███╗   ██╗██╗   ██╗███████╗");
            Console.WriteLine("     ██╔══██╗██║██╔════╝████╗  ██║██║   ██║██╔════╝████╗  ██║██║   ██║██╔════╝");
            Console.WriteLine("     ██████╔╝██║█████╗  ██╔██╗ ██║██║   ██║█████╗  ██╔██╗ ██║██║   ██║█████╗  ");
            Console.WriteLine("     ██╔══██╗██║██╔══╝  ██║╚██╗██║╚██╗ ██╔╝██╔══╝  ██║╚██╗██║██║   ██║██╔══╝  ");
            Console.WriteLine("     ██████╔╝██║███████╗██║ ╚████║ ╚████╔╝ ███████╗██║ ╚████║╚██████╔╝███████╗");
            Console.WriteLine("     ╚═════╝ ╚═╝╚══════╝╚═╝  ╚═══╝  ╚═══╝  ╚══════╝╚═╝  ╚═══╝ ╚═════╝ ╚══════╝");
            Console.WriteLine("");
            ConnaitreRegles();



            bool rejouer = true;

            while (rejouer == true)
            {
                // CHOISIR LA DIFFICULTÉ ----------------------------------------------------------------------------------------------------------------------------------------------------------

                string difficultéChoisie = ChoisirDifficulté();
                Console.Clear();

                // INITIALISATION DES VARIABLES : -------------------------------------------------------------------------------------------------------------------------------------------------


                bool victoire = false;

                string[] listePions = new string[] { "1111", "1110", "1101", "1100", "1011", "1010", "1001", "1000", "0111", "0110", "0101", "0100", "0011", "0010", "0001", "0000" };

                Console.WriteLine("");
                Console.WriteLine("     _  _ ____ _  _ ____    ____ ____ _  _ _  _ ____ _  _ ____ ____ ___  ");
                Console.WriteLine("     |  | |  | |  | [__     |    |  | |\\/| |\\/| |___ |\\ | |    |___   /  ");
                Console.WriteLine("      \\/  |__| |__| ___]    |___ |__| |  | |  | |___ | \\| |___ |___  /__ ");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                string[,] plateau = new string[4, 4] { { "....", "....", "....", "...." }, { "....", "....", "....", "...." }, { "....", "....", "....", "...." }, { "....", "....", "....", "...." } };

                Console.WriteLine("L'ordinateur est très fair-play, il vous laisse donc commencer ! ");
                Console.WriteLine("");
                Console.WriteLine("");



                //LANCEMENT DU JEU : ---------------------------------------------------------------------------------------------------------------------------------------------------------------

                if (difficultéChoisie == "0") //Pour un choix de difficulté "Facile" :
                {
                    AfficherPionsRestants(listePions);

                    while (victoire != true)
                    {

                        //Le joueur commence et donne un pion à son adversaire :

                        Console.WriteLine("    ");

                        string choix = ChoisirPion(listePions);

                        ModifierListePion(ref listePions, choix);


                        //L'ordinateur place son pion et donne un pion au joueur :

                        int choixColonne = PositionnerAléatoirement();
                        int choixLigne = PositionnerAléatoirement();

                        PositionnerPionAlea(choix, choixLigne, choixColonne, ref plateau);

                        AfficherPlateau(ref plateau, listePions);


                        //si l'ordinateur n'a pas gagné, c'est à nous de jouer

                        if (TesterVictoire(plateau, ref victoire) == false)
                        {
                            Console.WriteLine("L'adversaire a placé son pion. ");
                            Console.WriteLine("                                         ----");


                            //L'ordinateur choisi un pion à placer pour son adversaire :

                            string pion = ChoisirAleatoirement(listePions);

                            Console.WriteLine("A L'ADVERSAIRE DE CHOISIR : Il choisi   |" + pion + "|");

                            ModifierListePion(ref listePions, pion);

                            Console.WriteLine("                                         ----"); // aeration


                            //Au joueur de placer son pion :

                            ChoisirPositionnement(pion, ref plateau);

                            AfficherPlateau(ref plateau, listePions);


                            //On vérifie si le joueur à gagné :

                            if (TesterVictoire(plateau, ref victoire) == true)
                            {
                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("-----------------------------------------------------------------------");
                                Console.WriteLine("");
                                Console.WriteLine("         ██████╗ ██╗   ██╗ █████╗ ██████╗ ████████╗ ██████╗  ");
                                Console.WriteLine("        ██╔═══██╗██║   ██║██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗");
                                Console.WriteLine("        ██║   ██║██║   ██║███████║██████╔╝   ██║   ██║   ██║");
                                Console.WriteLine("        ██║▄▄ ██║██║   ██║██╔══██║██╔══██╗   ██║   ██║   ██║");
                                Console.WriteLine("        ╚██████╔╝╚██████╔╝██║  ██║██║  ██║   ██║   ╚██████╔╝");
                                Console.WriteLine("         ╚══▀▀═╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ");
                                Console.WriteLine("");
                                Console.WriteLine("-----------------------------------------------------------------------");
                                Console.WriteLine("");
                                Console.WriteLine("                       Vous êtes Vainqueur !");
                                Console.WriteLine("");
                                Console.WriteLine("Voulez-vous voir le plateau ? (o/n)");
                                string rep = Console.ReadLine();
                                if (rep == "o")
                                {
                                    AfficherPlateau(ref plateau, listePions);
                                }
                            }
                        }


                        //Si l'ordinateur a gagné en plaçant son pion, alors le joueur à perdu :
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("         ██████╗ ██╗   ██╗ █████╗ ██████╗ ████████╗ ██████╗  ");
                            Console.WriteLine("        ██╔═══██╗██║   ██║██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗");
                            Console.WriteLine("        ██║   ██║██║   ██║███████║██████╔╝   ██║   ██║   ██║");
                            Console.WriteLine("        ██║▄▄ ██║██║   ██║██╔══██║██╔══██╗   ██║   ██║   ██║");
                            Console.WriteLine("        ╚██████╔╝╚██████╔╝██║  ██║██║  ██║   ██║   ╚██████╔╝");
                            Console.WriteLine("         ╚══▀▀═╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ");
                            Console.WriteLine("");
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Vous avez perdu. L'ordinateur est meilleur que vous ...");
                            Console.WriteLine("");
                            Console.WriteLine("Voulez-vous voir le plateau ? (o/n)");
                            string rep = Console.ReadLine();
                            if (rep == "o")
                            {
                                AfficherPlateau(ref plateau, listePions);
                            }
                        }

                        FinirEgal(ref victoire, ref listePions);

                    }
                }

                else //Pour un choix de difficulté "Difficile" :
                {
                    AfficherPionsRestants(listePions);

                    while (victoire != true)
                    {

                        //Le joueur commence et donne un pion pour son adversaire :

                        Console.WriteLine("");
                        string choix = ChoisirPion(listePions);

                        ModifierListePion(ref listePions, choix);


                        //L'ordinateur place son pion et donne un pion au joueur :

                        ChoisirPositionnementOrdinateur(choix, ref plateau);

                        AfficherPlateau(ref plateau, listePions);


                        //si l'ordinateur n'a pas gagné, c'est à nous de jouer

                        if (TesterVictoire(plateau, ref victoire) == false)
                        {

                            Console.WriteLine("L'adversaire a placé son pion. ");
                            Console.WriteLine("    "); // aeration               


                            //L'ordinateur choisi un pion à placer pour son adversaire :

                            string pion = ChoisirPionOrdinateur(listePions, plateau);

                            Console.WriteLine("A L'ADVERSAIRE DE CHOISIR : Il choisi   " + pion);

                            ModifierListePion(ref listePions, pion);

                            Console.WriteLine("    "); // aeration


                            //Au joueur de placer son pion :

                            ChoisirPositionnement(pion, ref plateau);

                            AfficherPlateau(ref plateau, listePions);


                            //On vérifie si le joueur à gagné :

                            if (TesterVictoire(plateau, ref victoire) == true)
                            {
                                Console.Clear();
                                Console.WriteLine("");
                                Console.WriteLine("");
                                Console.WriteLine("-----------------------------------------------------------------------");
                                Console.WriteLine("");
                                Console.WriteLine("         ██████╗ ██╗   ██╗ █████╗ ██████╗ ████████╗ ██████╗  ");
                                Console.WriteLine("        ██╔═══██╗██║   ██║██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗");
                                Console.WriteLine("        ██║   ██║██║   ██║███████║██████╔╝   ██║   ██║   ██║");
                                Console.WriteLine("        ██║▄▄ ██║██║   ██║██╔══██║██╔══██╗   ██║   ██║   ██║");
                                Console.WriteLine("        ╚██████╔╝╚██████╔╝██║  ██║██║  ██║   ██║   ╚██████╔╝");
                                Console.WriteLine("         ╚══▀▀═╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ");
                                Console.WriteLine("");
                                Console.WriteLine("-----------------------------------------------------------------------");
                                Console.WriteLine("");
                                Console.WriteLine("                       Vous êtes Vainqueur !");
                                Console.WriteLine("");
                                Console.WriteLine("Voulez-vous voir le plateau ? (o/n)");
                                string rep = Console.ReadLine();
                                if (rep == "o")
                                {
                                    AfficherPlateau(ref plateau, listePions);
                                }
                            }
                        }


                        //Si l'ordinateur a gagné en plaçant son pion, alors le joueur à perdu :
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("         ██████╗ ██╗   ██╗ █████╗ ██████╗ ████████╗ ██████╗  ");
                            Console.WriteLine("        ██╔═══██╗██║   ██║██╔══██╗██╔══██╗╚══██╔══╝██╔═══██╗");
                            Console.WriteLine("        ██║   ██║██║   ██║███████║██████╔╝   ██║   ██║   ██║");
                            Console.WriteLine("        ██║▄▄ ██║██║   ██║██╔══██║██╔══██╗   ██║   ██║   ██║");
                            Console.WriteLine("        ╚██████╔╝╚██████╔╝██║  ██║██║  ██║   ██║   ╚██████╔╝");
                            Console.WriteLine("         ╚══▀▀═╝  ╚═════╝ ╚═╝  ╚═╝╚═╝  ╚═╝   ╚═╝    ╚═════╝ ");
                            Console.WriteLine("");
                            Console.WriteLine("-----------------------------------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("Vous avez perdus. L'ordinateur est meilleur que vous ...");
                            Console.WriteLine("");
                            Console.WriteLine("Voulez-vous voir le plateau ? (o/n)");
                            string rep = Console.ReadLine();
                            if (rep == "o")
                            {
                                AfficherPlateau(ref plateau, listePions);
                            }
                        }

                        FinirEgal(ref victoire, ref listePions);

                    }
                }
                Console.WriteLine("Voulez-vous rejouer ? (o/n)");
                if (Console.ReadLine() == "n")
                {
                    rejouer = false;
                }
            }
            Console.ReadKey();
        }





        /// <summary>
        /// Fonction pour déterminer la difficulté : 0 ou +
        /// </summary>
        /// <returns></returns>

        public static string ChoisirDifficulté()
        {
            Console.WriteLine("Quelle difficulté choisis-tu ? (0/+)");
            string difficultéChoisie = (Console.ReadLine());
            while ((difficultéChoisie != "0") && (difficultéChoisie != "+"))
            {
                Console.WriteLine("Il ne s'agit d'une difficulté existante. Quelle difficulté choisis-tu ? (0/+)");
                difficultéChoisie = (Console.ReadLine());
            }
            return difficultéChoisie;
        }

        public static void FinirEgal(ref bool victoire, ref  string [] listePions)
        {
            int cpt = 0;
            for (int i =0; i<16; i++)
            {
                    if (listePions[i]=="....")
                {
                    cpt++;
                }                
            }

            if (cpt == 16)
            {
                victoire = true;
                Console.Clear();
                Console.WriteLine(" Egalité .. ");
            }

        }

        /// <summary>
        /// Fonction pour que l'ordinateur place son pion aléatoirement :
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="ligne"></param>
        /// <param name="colonne"></param>
        /// <param name="plateau"></param>

        public static void PositionnerPionAlea(string piece, int ligne, int colonne, ref string[,] plateau)
        {
            while (plateau[ligne, colonne] != "....")
            {
                ligne = PositionnerAléatoirement();
                colonne = PositionnerAléatoirement();
            }
            plateau[ligne, colonne] = piece;

        }



        /// <summary>
        /// Fonction qui place le pion à l'endroit donné sur le plateau + vérification de la disponibilité de la case
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="ligne"></param>
        /// <param name="colonne"></param>
        /// <param name="plateau"></param>

        public static void PositionnerPion(string piece, int ligne, int colonne, ref string[,] plateau)
        {
            if (plateau[ligne, colonne] == "....")
            {
                plateau[ligne, colonne] = piece;
            }
            else
            {
                Console.WriteLine("La place est déjà occupée, veuillez choisir un nouvel emplacement : ");
                ChoisirPositionnement(piece, ref plateau);
            }

        }



        /// <summary>
        /// Fonction pour que le joueur choisisse un pion pour l'ordinateur :
        /// </summary>
        /// <param name="listePions"></param>
        /// <returns></returns>

        public static string ChoisirPion(string[] listePions)
        {
            Console.WriteLine("Quel pion choisis-tu pour ton adversaire ?");
            string pion = Console.ReadLine();
            int verif = 0;
            while (verif != 1)
            {
                for (int i = 0; i < listePions.Length; i++)
                {
                    if (pion == listePions[i])
                    {
                        verif = 1;
                    }
                }
                if (verif != 1)
                {
                    Console.WriteLine("Le pion que tu as choisi n'est plus disponible. Quel pion choisis-tu pour ton adversaire ?");
                    pion = Console.ReadLine();
                }
            }
            return pion;
        }


        /// <summary>
        /// Fonction pour que le joueur place son pion sur le plateau :
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="plateau"></param>

        public static void ChoisirPositionnement(string piece, ref string[,] plateau)
        {
            Console.WriteLine("Sur quelle ligne veux-tu placer ton pion ?");
            string lig = Convert.ToString(Console.ReadLine());
            int ligne = 0;
            int test = 0;
            while (test == 0)
            {
                if (lig == "A" || lig == "a")
                {
                    ligne = 0;
                    test = 1;
                }
                if (lig == "B" || lig == "b")
                {
                    ligne = 1;
                    test = 1;
                }
                if (lig == "C" || lig == "c")
                {
                    ligne = 2;
                    test = 1;
                }
                if (lig == "D" || lig == "d")
                {
                    ligne = 3;
                    test = 1;
                }
                if (test == 0)
                {
                    Console.WriteLine("Il ne s'agit pas d'une ligne correspondant au plateau. Sur quelle ligne veux-tu placer ton pion (A/B/C/D) ?");
                    lig = Convert.ToString(Console.ReadLine());
                }
            }
            Console.WriteLine("Sur quelle colonne veux-tu placer ton pion ?");
            int colonne = Convert.ToInt32(Console.ReadLine()) - 1;
            while (0 > colonne || colonne > 3)
            {
                Console.WriteLine("Il ne s'agit pas d'une colonne correspondant au plateau. Sur quelle colonne veux-tu placer ton pion ?");
                colonne = Convert.ToInt32(Console.ReadLine()) - 1;
            }
            int[] tableau = { ligne, colonne };
            if (0 <= colonne && colonne < 4)
            {
                PositionnerPion(piece, ligne, colonne, ref plateau); //Appel pour placer la pièce et vérifier que la case donnée est libre
            }
        }



        /// <summary>
        /// Fonction qui permet de générer un choix de pion aléatoire de l'ordinateur :
        /// </summary>
        /// <param name="tab"></param>
        /// <returns></returns>

        public static string ChoisirAleatoirement(string[] tab)
        {
            int l = tab.Length;
            Random aleatoire = new Random();
            int alea = aleatoire.Next(0, l - 1);
            string choix = tab[alea];
            while (choix == "....")
            {
                alea = aleatoire.Next(0, l - 1);
                choix = tab[alea];
            }
            return choix;
        }



        /// <summary>
        /// Fonction qui permet d'afficher les pions qu'il reste encore à placer :
        /// </summary>
        /// <param name="tab"></param>

        public static void AfficherPionsRestants(string[] tab)
        {
            Console.WriteLine("Les pions encore disponibles sont :");
            Console.WriteLine("");
            string a = tab[0];
            string b = tab[1];
            string c = tab[2];
            string d = tab[3];
            string e = tab[4];
            string f = tab[5];
            string g = tab[6];
            string h = tab[7];
            string i = tab[8];
            string j = tab[9];
            string k = tab[10];
            string l = tab[11];
            string m = tab[12];
            string n = tab[13];
            string o = tab[14];
            string p = tab[15];

            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("| " + a + " | " + b + " | " + c + " | " + d + " | " + e + " | " + f + " | " + g + " | " + h + " |");
            Console.WriteLine(" --------------------------------------------------------");
            Console.WriteLine("| " + i + " | " + j + " | " + k + " | " + l + " | " + m + " | " + n + " | " + o + " | " + p + " | ");
            Console.WriteLine(" --------------------------------------------------------");
        }



        /// <summary>
        /// Fonction qui génère un choix de positionnement aléatoire de l'ordinateur (à appeler 2 fois pour obtenir un couple) :
        /// </summary>
        /// <returns></returns>

        public static int PositionnerAléatoirement()
        {

            Random aleatoire = new Random();
            int a = aleatoire.Next(0, 4);

            return a;
        }



        /// <summary>
        /// Fonction qui met à jour la liste de pions :
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="choix"></param>

        public static void ModifierListePion(ref string[] tab, string choix)
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == choix)
                {
                    tab[i] = "....";
                }
            }
        }



        /// <summary>
        /// Fonction qui permet de comparer une caractéristique entre deux pions donnés et qui regarde si elles sont identiques ou non :
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="c1"></param>
        /// <param name="l2"></param>
        /// <param name="c2"></param>
        /// <param name="caractère"></param>
        /// <param name="tab"></param>
        /// <returns></returns>

        public static bool ComparerDeuxPions(int l1, int c1, int l2, int c2, int caractère, string[,] tab)
        {
            string a = tab[l1, c1];
            string b = tab[l2, c2];
            char c = a[caractère];
            char d = b[caractère];
            if (c == '.' || d == '.')
            {
                return false;
            }
            if (a[caractère] == b[caractère])
            {
                return true;
            }
            return false;
        }



        /// <summary>
        /// Fonction qui test si il y a victoire d'un des deux joueurs :
        /// </summary>
        /// <param name="plateau"></param>
        /// <param name="victoire"></param>
        /// <returns></returns>

        public static bool TesterVictoire(string[,] plateau, ref bool victoire)
        {


            //test victoire en ligne

            for (int ligne = 0; ligne < 4; ligne++)
            {
                int cpt = 0;
                for (int carac = 0; carac < 4; carac++)
                {

                    for (int col = 0; col < 3; col++)
                    {
                        if (ComparerDeuxPions(ligne, col, ligne, col + 1, carac, plateau) == true)
                        {
                            cpt++;
                        }
                    }
                    if (cpt == 3)
                    {
                        victoire = true;
                        return true;
                    }
                    else cpt = 0;
                }

            }




            //test victoire en colonne

            for (int col = 0; col < 4; col++)
            {
                int cpt = 0;
                for (int carac = 0; carac < 4; carac++)
                {

                    for (int ligne = 0; ligne < 3; ligne++)
                    {
                        if (ComparerDeuxPions(ligne, col, ligne + 1, col, carac, plateau) == true)
                        {
                            cpt++;
                        }
                    }
                    if (cpt == 3)
                    {
                        victoire = true;
                        return true;
                    }
                    else cpt = 0;
                }

            }




            //test victoire en diagonale droite

            for (int carac = 0; carac < 4; carac++)
            {
                int cpt = 0;
                for (int var = 0; var < 3; var++)
                {
                    if (ComparerDeuxPions(var, var, var + 1, var + 1, carac, plateau) == true)
                    {
                        cpt++;
                    }

                    if (cpt == 3)
                    {
                        victoire = true;
                        return true;
                    }
                }

            }


            //test victoire en diagonale gauche

            for (int carac = 0; carac < 4; carac++)
            {
                int cpt = 0;
                for (int var = 0; var < 3; var++)
                {
                    if (ComparerDeuxPions(var, 3 - var, var + 1, 2 - var, carac, plateau) == true)
                    {
                        cpt++;
                    }

                    if (cpt == 3)
                    {
                        victoire = true;
                        return true;
                    }
                }

            }

            return false;

        }


        /// <summary>
        /// Fonction permettant d'afficher le plateau dans son état actuel :
        /// </summary>
        /// <param name="tab"></param>
        /// <param name="listePions"></param>

        public static void AfficherPlateau(ref string[,] tab, string[] listePions)
        {
            Console.Clear();

            Console.WriteLine(" _____ __     ___  _____ _____  ___  __ __    _____ _____       __ _____ __ __ ");
            Console.WriteLine(" ||_// ||    ||=||  ||   ||==  ||=|| || ||    ||  ) ||==        || ||==  || || ");
            Console.WriteLine(" ||    ||__| || ||  ||   ||___ || || \\(_//    ||_// ||___    |__|| ||___ \\(_// ");
            Console.WriteLine("");
            Console.WriteLine("");


            string a = tab[0, 0];
            string b = tab[0, 1];
            string c = tab[0, 2];
            string d = tab[0, 3];
            string e = tab[1, 0];
            string f = tab[1, 1];
            string g = tab[1, 2];
            string h = tab[1, 3];
            string i = tab[2, 0];
            string j = tab[2, 1];
            string k = tab[2, 2];
            string l = tab[2, 3];
            string m = tab[3, 0];
            string n = tab[3, 1];
            string o = tab[3, 2];
            string p = tab[3, 3];


            Console.WriteLine("                            1        2        3        4      ");
            Console.WriteLine("                     --------------------------------------");
            Console.WriteLine("                   A |    " + a + "  |  " + b + "  |  " + c + "  |  " + d + " |");
            Console.WriteLine("                     |-------------------------------------");
            Console.WriteLine("                   B |    " + e + "  |  " + f + "  |  " + g + "  |  " + h + " |");
            Console.WriteLine("                     |-------------------------------------");
            Console.WriteLine("                   C |    " + i + "  |  " + j + "  |  " + k + "  |  " + l + " |");
            Console.WriteLine("                     |-------------------------------------");
            Console.WriteLine("                   D |    " + m + "  |  " + n + "  |  " + o + "  |  " + p + " |");
            Console.WriteLine("                     --------------------------------------");
            Console.WriteLine("");
            AfficherPionsRestants(listePions);
            Console.WriteLine("");

        }



        /// <summary>
        /// Fonction permettant de faire choisir la place d'un pion à l'ordinateur de manière intelligente :
        /// </summary>
        /// <param name="piece"></param>
        /// <param name="plateau"></param>

        public static void ChoisirPositionnementOrdinateur(string piece, ref string[,] plateau)
        {
            bool peutGagner = false;
            int ligne = 10;
            int colonne = 10;
            string[,] testplateau = new string[4, 4];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (plateau[i, j] == "....") //Choix d'une place vide du plateau où peut se pose un nouveau pion
                    {
                        for (int k = 0; k < 4; k++) //Un nouveau plateau de test est créé
                        {
                            for (int l = 0; l < 4; l++)
                            {
                                testplateau[k, l] = plateau[k, l];
                            }
                        }
                        testplateau[i, j] = piece; //On place le pion sur le plateau de test
                        if (TesterVictoire(testplateau, ref peutGagner) == true) //On regarde si la place choisi pour le pion permet à l'ordinateur de gagner la partie
                        {
                            ligne = i;
                            colonne = j;
                        }
                    }
                }
            }
            if ((ligne != 10) && (colonne != 10)) //Si les deux variables ont été modifiées, cela veut donc dire qu'elles correspondent à une place de pion qui permettrait à l'ordinateur de gagner.
            {
                PositionnerPion(piece, ligne, colonne, ref plateau); // ... on place donc la pièce à cet endroit.
            }
            else //Si les deux sont restées les mêmes, il n'existe donc pas de position permettant à l'ordinateur de gagner, on peut donc placer la pièce n'importe où sur le plateau.
            {
                int choixColonne = PositionnerAléatoirement();
                int choixLigne = PositionnerAléatoirement();

                PositionnerPionAlea(piece, choixLigne, choixColonne, ref plateau);
            }

        }


        /// <summary>
        /// Fonction permettant de faire choisir un pion à l'ordinateur de manière intelligente :
        /// </summary>
        /// <param name="listePions"></param>
        /// <param name="plateau"></param>
        /// <returns></returns>

        public static string ChoisirPionOrdinateur(string[] listePions, string[,] plateau)
        {
            string[,] testplateau = new string[4, 4];
            bool peutGagner = false;
            for (int a = 0; a < listePions.Length; a++) //Pour chaque pièce encore disponible ...
            {
                bool possibilitéVictoire = false;
                string piece = listePions[a];
                if (piece != "....")
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            for (int k = 0; k < 4; k++)
                            {
                                for (int l = 0; l < 4; l++)
                                {
                                    testplateau[k, l] = plateau[k, l]; // ... on test sur un plateau virtuel ...
                                }
                            }
                            if (plateau[i, j] == "....")
                            {
                                testplateau[i, j] = piece;
                                if (TesterVictoire(testplateau, ref peutGagner) == true) // ... si il existe une position dans laquelle elle permettrait au joueur de gagner la partie.
                                {
                                    possibilitéVictoire = true;
                                }
                            }
                        }
                    }
                    if (possibilitéVictoire == false) //Si la pièce testée ne lui permet pas de gagner, alors l'ordinateur peut choisir cette pièce.
                    {
                        return piece;
                    }
                }
            }
            string pieceHasard = ChoisirAleatoirement(listePions);
            return pieceHasard; //Si pour toutes les pièces testées, le joueur gagne, l'ordinateur en choisit une au hasard parmi les pièces restantes.


        }

        /// <summary>
        /// Fonction permettant d'afficher les règles du jeu au joueur si il le souhaite :
        /// </summary>

        public static void ConnaitreRegles()
        {
            Console.WriteLine("Veux-tu connaître les règles du jeu Quarto ? (o/n)");
            string rep = Console.ReadLine();
            if (rep == "o")
            {
                Console.WriteLine("");
                Console.WriteLine("Voici les règles du jeu :");
                Console.WriteLine("");
                Console.WriteLine("Ce jeu est un jeu de logique.");
                Console.WriteLine("Les pièces ont chacune 4 caractéristiques différentes : '....'");
                Console.WriteLine("Chacune d'entre elles peut prendre deux valeurs différentes : 1 ou 0.");
                Console.WriteLine("Exemple : '1010'");
                Console.WriteLine("");
                Console.WriteLine("Pour gagner, il faut donc aligner quatre pions ayant au moins une ");
                Console.WriteLine("caractéristique commune. (horizontalement, verticalement ou diagonalement)");
                Console.WriteLine("Il existe deux niveaux de difficulté, facile (0) ou difficile (+).");
                Console.WriteLine("");
            }
        }
    }
}















