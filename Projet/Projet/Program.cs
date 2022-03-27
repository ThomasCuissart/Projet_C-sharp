using System;
using System.Text.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Projet
{
    class Program
    {
        static void Main(string[] args)
        {
            //liste pour chaque générations
            List<Pokemon> gen1 = new List<Pokemon>();
            List<Pokemon> gen2 = new List<Pokemon>();
            List<Pokemon> gen3 = new List<Pokemon>();
            List<Pokemon> gen4 = new List<Pokemon>();
            List<Pokemon> gen5 = new List<Pokemon>();
            List<Pokemon> gen6 = new List<Pokemon>();
            List<Pokemon> gen7 = new List<Pokemon>();
            List<Pokemon> gen8 = new List<Pokemon>();


            //remplisage des liste avec la fonction newPoke
            var Gen1 = Task.Run(() => newPoke(1, 151, ref gen1));
            var Gen2 = Task.Run(() => newPoke(152, 251, ref gen2));
            var Gen3 = Task.Run(() => newPoke(252, 386, ref gen3));
            var Gen4 = Task.Run(() => newPoke(387, 493, ref gen4));
            var Gen5 = Task.Run(() => newPoke(388, 649, ref gen5));
            var Gen6 = Task.Run(() => newPoke(650, 721, ref gen6));
            var Gen7 = Task.Run(() => newPoke(722, 802, ref gen7));
            var Gen8 = Task.Run(() => newPoke(803, 898, ref gen8));

            //on attend que toute les listes soie fini
            Task.WaitAll(Gen1, Gen2, Gen3, Gen4, Gen5, Gen6, Gen7, Gen8);

            //Affichage de toute les genration
            for (int i = 1; i <= 8; i++)
            {
                Affich1gen(gen1, gen2, gen3, gen4, gen5, gen6, gen7, gen8, i);
            }

            // retour a la ligne et vaguelette pour avoir une meilleur lisibilité dans le terminal
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            // Demande quelgénération a afficher
            int generation;
            Console.WriteLine("donner une génération à afficher");
            generation = Convert.ToInt32(Console.ReadLine());

            // appel de la fonction qui affiche une génération
            Affich1gen(gen1, gen2, gen3, gen4, gen5, gen6, gen7, gen8, generation);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            //Affiche 1 type de pokemon par gen d'ou les 8 appels 

            string TypeofPoke;
            Console.WriteLine("Donnez un type de pokemon a afficher");
            TypeofPoke = Console.ReadLine();
            Affich1Type(gen1, TypeofPoke);
            Affich1Type(gen2, TypeofPoke);
            Affich1Type(gen3, TypeofPoke);
            Affich1Type(gen4, TypeofPoke);
            Affich1Type(gen5, TypeofPoke);
            Affich1Type(gen6, TypeofPoke);
            Affich1Type(gen7, TypeofPoke);
            Affich1Type(gen8, TypeofPoke);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            //Affichage du poids des pokemons de type Steel

            string TypePoke = "Steel";
            int res = (MoyPoidsPoke(gen1, TypePoke) +
                MoyPoidsPoke(gen2, TypeofPoke) +
                MoyPoidsPoke(gen3, TypeofPoke) +
                MoyPoidsPoke(gen4, TypeofPoke) +
                MoyPoidsPoke(gen5, TypeofPoke) +
                MoyPoidsPoke(gen6, TypeofPoke) +
                MoyPoidsPoke(gen7, TypeofPoke) +
                MoyPoidsPoke(gen8, TypeofPoke)) / 8;
            Console.WriteLine("Le poids des types acier est de : " + res);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            //Affiche 1Pokemon part Type et cela pour chaque génration --1 appel 1 gen

            Affiche1TparG(gen1);
            Affiche1TparG(gen2);
            Affiche1TparG(gen3);
            Affiche1TparG(gen4);
            Affiche1TparG(gen5);
            Affiche1TparG(gen6);
            Affiche1TparG(gen7);
            Affiche1TparG(gen8);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            //donnes les Info d'un pokemon au choix (avec son nom)

            Console.WriteLine("Donnez un nom de Pokemon pour avoir plus d'info");
            string Nompoke = Console.ReadLine();

            Affinfopoke(gen1, Nompoke);
            Affinfopoke(gen2, Nompoke);
            Affinfopoke(gen3, Nompoke);
            Affinfopoke(gen4, Nompoke);
            Affinfopoke(gen5, Nompoke);
            Affinfopoke(gen6, Nompoke);
            Affinfopoke(gen7, Nompoke);
            Affinfopoke(gen8, Nompoke);

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("");
            Console.WriteLine("");

            //donnes les Info d'un pokemon au choix (avec son ID)

            Console.WriteLine("Donnez un id de Pokemon pour plus d'info");
            int Numpokemon = Convert.ToInt32(Console.ReadLine());

            AffinfopokeByNum(gen1, Numpokemon);
            AffinfopokeByNum(gen2, Numpokemon);
            AffinfopokeByNum(gen3, Numpokemon);
            AffinfopokeByNum(gen4, Numpokemon);
            AffinfopokeByNum(gen5, Numpokemon);
            AffinfopokeByNum(gen6, Numpokemon);
            AffinfopokeByNum(gen7, Numpokemon);
            AffinfopokeByNum(gen8, Numpokemon);

        }

        //Fonctions qui affiche les info d'un pokemon a partir de son Id
        private static void Affinfopoke(List<Pokemon> gen, string Nompoke)
        {
            foreach (Pokemon numpoke in gen)
            {
                if (Nompoke == numpoke.name.fr)
                {
                    foreach (string typePoke in numpoke.types)
                    {
                        Console.WriteLine("Type : " + typePoke);
                    }
                    Console.WriteLine("Taille : " + numpoke.height);
                    Console.WriteLine("poid : " + numpoke.weight);
                    Console.WriteLine("genre : " + numpoke.genus.fr);
                    Console.WriteLine("description : " + numpoke.description.fr);
                    Console.WriteLine("stats : ");
                    foreach (Stats numstat in numpoke.stats)
                    {
                        Console.WriteLine("nom : " + numstat.name);
                        Console.WriteLine("stat : " + numstat.stat);
                    }
                    Console.WriteLine("Last edit" + numpoke.lastEdit);
                }
            }
        }

        //Fonctions qui affiche les info d'un pokemon a partir de son nom
        private static void AffinfopokeByNum(List<Pokemon> gen, int Numpokemon)
        {
            foreach (Pokemon numpoke in gen)
            {
                if (Numpokemon == numpoke.id)
                {
                    foreach (string typePoke in numpoke.types)
                    {
                        Console.WriteLine("Type : " + typePoke);
                    }
                    Console.WriteLine("Taille : " + numpoke.height);
                    Console.WriteLine("poid : " + numpoke.weight);
                    Console.WriteLine("genre : " + numpoke.genus.fr);
                    Console.WriteLine("description : " + numpoke.description.fr);
                    Console.WriteLine("stats : ");
                    foreach (Stats numstat in numpoke.stats)
                    {
                        Console.WriteLine("nom : " + numstat.name);
                        Console.WriteLine("stat : " + numstat.stat);
                    }
                    Console.WriteLine("Last edit : " + numpoke.lastEdit);
                }
            }
        }

        //affiche dans une liste un pokemon par Type
        private static void Affiche1TparG(List<Pokemon> gen)
        {
            List<string> TypeSave = new List<string>();
            Boolean nouveautype = true;
            foreach (Pokemon numpoke in gen)
            {
                foreach (string typepoke in numpoke.types)
                {
                    foreach (string typetab in TypeSave)
                    {
                        if (typepoke == typetab)
                        {
                            nouveautype = false;
                        }
                    }
                }
                if (nouveautype)
                {
                    Console.WriteLine("N°: " + numpoke.id + " Nom: " + numpoke.name.fr);
                    foreach (string typepokeadd in numpoke.types)
                    {
                        TypeSave.Add(typepokeadd); // on ajoute les types deja affiché a un tableau
                    }
                }
                nouveautype = true;
            }
            TypeSave.Clear();// on vide le tableau après avoir épluché la liste
        }

        // Fonction qui parcours un tableau et qui fait le moyenne des poids poir un Type de Pokemon
        private static int MoyPoidsPoke(List<Pokemon> gen1, string TypeofPoke)
        {
            int nb = 0;
            int poid = 0;
            foreach (Pokemon numpoke in gen1)
            {
                foreach (string type in numpoke.types)
                {
                    if (type == TypeofPoke)
                    {
                        poid += numpoke.weight;
                        nb++;
                    }
                }
            }
            if (nb == 0) return (0);
            else return (poid/nb); //retorne la moyenne des poids 
        }


        //ce balade dans une liste est afffiche un seul type de pokemon
        private static void Affich1Type(List<Pokemon> Gen,string TypeofPoke)
        {
            foreach (Pokemon numepoke in Gen)
            {
                foreach (string type in numepoke.types)
                {
                    if (type == TypeofPoke)
                    {
                        Console.WriteLine("N°: " + numepoke.id + " Nom: " + numepoke.name.fr);
                    }
                }
            }
        }

        //affiche une liste entière de pokémon (toute une génération)
        private static void Affich1gen(List<Pokemon> gen1, List<Pokemon> gen2, List<Pokemon> gen3, List<Pokemon> gen4, List<Pokemon> gen5, List<Pokemon> gen6, List<Pokemon> gen7, List<Pokemon> gen8,int generation)
        {
            switch (generation)
            {
                case 1:
                    foreach (Pokemon numliste in gen1)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 2:
                    foreach (Pokemon numliste in gen2)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 3:
                    foreach (Pokemon numliste in gen3)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 4:
                    foreach (Pokemon numliste in gen4)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 5:
                    foreach (Pokemon numliste in gen5)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 6:
                    foreach (Pokemon numliste in gen6)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 7:
                    foreach (Pokemon numliste in gen7)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

                case 8:
                    foreach (Pokemon numliste in gen8)
                    {
                        Console.WriteLine("N°: " + numliste.id + " Nom: " + numliste.name.fr);
                    }
                    break;

            }
        }

        //récupération des information du json pour les mettres dans une liste 
        static void newPoke(int min, int max, ref List<Pokemon> p)
        {
            for (int pos = min; pos <= max; pos++)
            {
                using (System.Net.WebClient webClient = new System.Net.WebClient())
                {
                    string jsonString = webClient.DownloadString("https://tmare.ndelpech.fr/tps/pokemons/" + pos);
                    p.Add(JsonSerializer.Deserialize<Pokemon>(jsonString));
                }
            }
        }
    }
}
