using System;

namespace MyPayes
{
    public class ClassPayes
    {
        //Point
        readonly int Point = 45;

        //indic
        public int Indic(int cat)
        {
            int vals;
            if (cat >= 11 & cat <= 17){vals = 18;}
            else if (cat >= 9 & cat <= 10){ vals = 10;}
            else if (cat >= 7 & cat <= 8){vals = 4;}
            else{vals = 0;}
            return vals + (cat - 1) * 19 + 250 + (cat - 2) * (cat - 1);
        }
        //indic Echelon
        public int IepIndic(int Cat, int Echlon)
        {
            int Nplus = Echlon switch
            {
                1 => 3,
                2 => 5,
                3 => 8,
                4 => 10,
                5 => 13,
                6 => 15,
                7 => 18,
                8 => 20,
                9 => 23,
                10 => 25,
                11 => 28,
                12 => 30,
                _ => 0,
            };
            double Resultat = (Indic(Cat) - 50) * 0.05 * Echlon + Nplus;
            return Convert.ToInt32 (Math.Round(Resultat));

        }
        //Saler de Base
        public double Saler(int Cat)
        {
            return Indic(Cat) * Point;
        }
        //IEP
        public double Iep(int Cat, int Echlon)
        {
            return IepIndic(Cat, Echlon) * Point;
        }

        //IRG 2022
        public double IRG2022_New(int TypeIRG, double Soumis)
        {
            //Variables
            
            double Irg = 0;
            double P = ((int)(Soumis / 10)) * 10; // Math.Truncate(Soumis);
            //P -= P % 10;

            if (Soumis <= 30000)
            {
                Irg = 0;
            }
            else
            {
                if (Soumis > 20000 & Soumis <= 40000) { Irg = (P - 20000) * 0.23; }
                else if (Soumis > 40000 & Soumis <= 80000) { Irg = 4600 + (P - 40000) * 0.27; }
                else if (Soumis > 80000 & Soumis <= 160000) { Irg = 15400 + (P - 80000) * 0.30; }
                else if (Soumis > 160000 & Soumis <= 320000) { Irg = 39400 + (P - 160000) * 0.33; }
                else if (Soumis > 320000) { Irg = 92200 + (P - 320000) * 0.35; }

                double Abat = 0.4 * Irg;
                if (Abat < 1000) { Abat = 1000; }
                if (Abat > 1500) { Abat = 1500; }
                Irg -= Abat;
                
                // 1= Normal 2= Handicape
                switch (TypeIRG)
                {
                    case 1: //---->Normal
                        if (Soumis > 30000 & Soumis <= 35000) { Irg = Math.Round(Irg * (137 / 51) - (27925 / 8), 1); }
                        break;
                    case 2: //---->Handicape
                        if (Soumis < 42500) { Irg = Math.Round(Irg * 93 / 61 - 81213 / 41, 1); }
                        break;
                    default:
                        //Irg = Math.Round(Irg, 1);
                        break;
                }
            }
            return Irg;
        }
        //Prime IFC
        public float IFC(int Categori)
        {
            float Prime = Categori switch
            {
                1 => 7700,
                2 => 7400,
                3 => 6900,
                4 => 6400,
                5 => 5700,
                6 => 5000,
                7 => 3800,
                8 => 3800,
                9 => 3100,
                10 => 3100,
                _ => 1500,
            };
            return Prime;
        }
    }
}
