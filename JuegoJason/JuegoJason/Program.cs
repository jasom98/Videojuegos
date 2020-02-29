using System;

namespace JuegoJason
{
    class Program
    {
        private const int V = 1;
        private const int V1 = 20;
        private const int V2 = 30;
        private const int V3 = 50;

        static void Main(string[] args)
        {
            bool game = true;
            int nivel;
            int jugadores;
            Console.Clear();
            jugadores = Seleccion_jugadores();
            nivel = Seleccion_nivel();
            Console.WriteLine(".::CONSTRUYENDO TABLERO NIVEL " + nivel + " CON " + jugadores + " JUGADORES::.");
            int[,,] juego = Crear_tablero(jugadores, nivel);
            while (game)
            {
                Console.WriteLine("====TABLERO ACTUAL====");
                Mostrar_tablero(juego, nivel);
                Console.WriteLine("======================");
                for (int i = 0; i < juego.Length; i++)
                {
                    Console.WriteLine(".::TURNO DEL JUGADOR " + (i + 1) + " ::.");

                    if (juego[0, i, 0] <= 6)
                    {
                        int dado_unitario = new Random().Next(1, 6);
                        Console.WriteLine("DADO UNO " + dado_unitario);
                        juego[0, i, 0] = juego[0, i, 0] - dado_unitario;
                        if (juego[0, i, 0] < 0)
                        {
                            juego[0, i, 0] = juego[0, i, 0] + dado_unitario;
                        }
                        if (juego[0, i, 0] == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("GANADOR JUGADOR " + (i + 1));
                            game = false;
                            break;
                        }
                    }
                    else
                    {
                        int dado = Dados();
                        if (dado == 0)
                        {
                            game = false;
                            Console.Clear();
                            Console.WriteLine("UD SACO 3 PARES CONSECUTIVOS ");
                            Console.WriteLine("POR SUERTE GANA JUGADOR " + (i + 1));
                            break;
                        }
                        juego[0, i, 0] = juego[0, i, 0] - dado;
                        if (juego[0, i, 0] < 0)
                        {
                            juego[0, i, 0] = juego[0, i, 0] + dado;
                        }
                        if (juego[0, i, 0] == 0)
                        {
                            Console.Clear();
                            game = false;
                            Console.WriteLine("GANADOR JUGADOR " + (i + 1));
                            break;
                        }
                    }

                }
                Console.WriteLine("====TABLERO RESULTANTE====");
                Mostrar_tablero(juego, nivel);
                Console.WriteLine("======================");
                Console.WriteLine("PRESIONE ENTER PARA CONTINUAR");
                string valor_jugadores = Console.ReadLine();
                Console.Clear();
            }

        }

        static void Mostrar_tablero(int[,,] juego, int nivel)
        {
            for (int i = 0; i < juego.Length; i++)
            {
                switch (nivel)
                {

                    case 1:
                        Console.WriteLine("Jugador " + (i + 1) + " " + (V1 - juego[0, i, 0]));
                        break;
                    case 2:
                        Console.WriteLine("Jugador " + (i + 1) + " " + (V2 - juego[0, i, 0]));
                        break;
                    case 3:
                        Console.WriteLine("Jugador " + (i + 1) + " " + (V3 - juego[0, i, 0]));
                        break;
                }

            }
        }
        static int Dados()
        {
            int dadoA = new Random().Next(1, 6);
            int dadoB = new Random().Next(1, 6);
            int total = dadoA + dadoB;
            if (dadoB == dadoA)
            {
                Console.WriteLine("PERFECTO SACASTE UN PAR");
                Console.WriteLine("DADO UNO = " + dadoA + " DADO DOS = " + dadoB + " TOTAL " + total);
                dadoA = new Random().Next(1, 6);
                dadoB = new Random().Next(1, 6);
                if (dadoB == dadoA)
                {
                    Console.WriteLine("PERFECTO OTRO PAR UNO MAS Y GANAS");
                    total = total + dadoA + dadoB;
                    Console.WriteLine("DADO UNO = " + dadoA + " DADO DOS = " + dadoB + " TOTAL " + (dadoA + dadoB));
                    dadoA = new Random().Next(1, 6);
                    dadoB = new Random().Next(1, 6);
                    if (dadoB == dadoA)
                    {
                        return 0;
                    }
                    Console.WriteLine("DADO UNO = " + dadoA + " DADO DOS = " + dadoB + " TOTAL " + (dadoA + dadoB));
                    total = total + dadoA + dadoB;
                    Console.WriteLine("EN TOTAL " + total);
                    return total;
                }
                Console.WriteLine("DADO UNO = " + dadoA + " DADO DOS = " + dadoB + " TOTAL " + (dadoA + dadoB));
                total = total + dadoA + dadoB;
                Console.WriteLine("EN TOTAL " + total);
                return total;
            }
            Console.WriteLine("DADO UNO = " + dadoA + " DADO DOS = " + dadoB + " TOTAL " + total);
            return total;
        }

        static int participantes(String jugador)
        {
            switch (jugador)
            {
                case "2":
                    Console.Clear();
                    Console.WriteLine("ud escojio 2 jugadores");
                    return 2;

                case "3":
                    Console.Clear();
                    Console.WriteLine("ud escojio 3 jugadores");
                    return 3;
                case "4":
                    Console.Clear();
                    Console.WriteLine("ud escojio 4 jugadores");
                    return 4;

                default:
                    Console.Clear();
                    Console.WriteLine("X__x El numero de jugadores no esta dentro del rango x_X");
                    return 0;
            }
        }

        static int NIVEL(String nivel)
        {
            switch (nivel)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("NIVEL BASICO");
                    return 1;

                case "2":
                    Console.Clear();
                    Console.WriteLine("NIVEL INTERMEDIO");
                    return 2;
                case "3":
                    Console.Clear();
                    Console.WriteLine("NIVEL AVANZADO");
                    return 3;

                default:
                    Console.Clear();
                    Console.WriteLine("X__x EL NIVEL NO EXISTEx_X");
                    return 0;
            }
        }

        static int Seleccion_jugadores()
        {
            while (true)
            {
                Console.WriteLine(".::CARRERA NUMERICA::.");
                Console.WriteLine("DIGITE NUMERO DE JUGADORES");
                string valor_jugadores = Console.ReadLine();
                int player;
                player = participantes(valor_jugadores);
                if (player != 0)
                {
                    return player;
                }
            }
        }
        static int Seleccion_nivel()
        {

            while (true)
            {
                Console.WriteLine("SELECCION EL NIVEL DEL TABLERO");
                Console.WriteLine("1. NIVEL BASICO(TABLERO DE 20 POSICIONES)");
                Console.WriteLine("2. NIVEL INTERMEDIO(TABLERO DE 30 POSICIONES)");
                Console.WriteLine("3. NIVEL AVANZADO(TABLERO DE 50 POSICIONES)");
                Console.WriteLine("DIGITE NIVEL");
                string valor_nivel = Console.ReadLine();
                int lve;
                lve = NIVEL(valor_nivel);
                if (lve != 0)
                {
                    Console.Clear();
                    return lve;
                }
            }
        }
        static int[,,] Crear_tablero(int jugadores, int nivel)
        {
            int[,,] tablero;
            tablero = new int[1, jugadores, 1];
            for (int i = 0; i <= jugadores - 1; i++)
            {
                switch (nivel)
                {
                    case 1:
                        tablero[0, i, 0] = V1;
                        break;
                    case 2:
                        tablero[0, i, 0] = V2;
                        break;
                    case 3:
                        tablero[0, i, 0] = V3;
                        break;
                }

            }

            return tablero;

        }

    }
}
