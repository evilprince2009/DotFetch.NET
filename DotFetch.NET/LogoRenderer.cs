using System.Collections.Generic;

namespace DotFetch.NET
{
    public class LogoRenderer
    {
        public static List<string> LogoAscii()
        {
            List<string> logo = null;
            if (InformationGenerator.GetOS().ToLower().Contains("windows 10"))
            {
                logo = WindowsX();
            }
            else if (InformationGenerator.GetOS().ToLower().Contains("windows 11"))
            {
                logo = WindowsXI();
            }
            else
            {
                logo = DefaultDevil();
            }

            return CrossSkull();
        }

        private static List<string> CrossSkull()
        {
            List<string> AsciiArt = new()
            {
                { "NO!                          MNO!          " },
                { "     MNO!!         [NBK]          MNNOO!   " },
                { "   MMNO!                           MNNOO!! " },
                { " MNOONNOO!   MMMMMMMMMMPPPOII!   MNNO!!!!  " },
                { " !O! NNO! MMMMMMMMMMMMMPPPOOOII!! NO!      " },
                { "       ! MMMMMMMMMMMMMPPPPOOOOIII! !       " },
                { "        MMMMMMMMMMMMPPPPPOOOOOOII!!        " },
                { "        MMMMMOOOOOOPPPPPPPPOOOOMII!        " },
                { "        MMMMM..    OPPMMP    .,OMI!        " },
                { "        MMMM::   o.,OPMP,.o   ::I!!        " },
                { "          NNM:::.,,OOPM!P,.::::!!          " },
                { "         MMNNNNNOOOOPMO!!IIPPO!!O!         " },
                { "         MMMMMNNNNOO:!!:!!IPPPPOO!         " },
                { "          MMMMMNNOOMMNNIIIPPPOO!!          " },
                { "             MMMONNMMNNNIIIOO!             " },
                { "           MN MOMMMNNNIIIIIO! OO           " },
                { "          MNO! IiiiiiiiiiiiI OOOO          " },
                { "     NNN.MNO!   O!!!!!!!!!O   OONO NO!     " },
                { "    MNNNNNO!    OOOOOOOOOOO    MMNNON!     " },
                { "      MNNNNO!    PPPPPPPPP    MMNON!       " },
                { "         OO!                   ON!         " }
            };
            return AsciiArt;
        }

        private static List<string> DefaultDevil()
        {
            List<string> AsciiArt = new()
            {
                { @"                                                                        " },
                { @"             (`)..                                    ,.-')             " },
                { @"              (',.)-..                            ,.-(..`)              " },
                { @"               (,.' ,.)-..                    ,.-(. `.. )               " },
                { @"                (,.' ..' .)-..            ,.-( `.. `.. )                " },
                { @"                 (,.' ,.'  ..')-.     ,.-( `. `.. `.. )                 " },
                { @"                  (,.'  ,.' ,.'  )-.-('   `. `.. `.. )                  " },
                { @"                   ( ,.' ,.'    _== ==_     `.. `.. )                   " },
                { @"                    ( ,.'   _==' ~  ~  `==_    `.. )                    " },
                { @"                     \  _=='   ----..----  `==_   )                     " },
                { @"                  ,.-:    ,----___.  .___----.    -..                   " },
                { @"              ,.-'   (   _--====_  \/  _====--_   )  `-..               " },
                { @"          ,.-'   .__.'`.  `-_I0_-'    `-_0I_-'  .'`.__.  `-..           " },
                { @"      ,.-'.'   .'      (          |  |          )      `.   `.-..       " },
                { @"  ,.-'    :    `___--- '`.__.    / __ \    .__.' `---___'    :   `-..   " },
                { @"-'_______`-EVILPRINCE2009'__ \  (O)  (O)  / __`______________-'______`- " },
                { @"                            \ . _  __  _ . /                            " },
                { @"                             \ `V-'  `-V' |                             " },
                { @"                              | \ \ | /  /                              " },
                { @"                               V \ ~| ~/V                               " },
                { @"                                |  \  /|                                " },
                { @"                                 \~ | V                                 " },
                { @"                                  \  |                                  " },
                { @"                                   VV                                   " }
            };

            return AsciiArt;
        }

        private static List<string> WindowsX()
        {
            List<string> AsciiArt = new()
            {
                { "                         ....::::       " },
                { "                 ....::::::::::::       " },
                { "        ....:::: ::::::::::::::::       " },
                { "....:::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { "................ ................       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { "'''':::::::::::: ::::::::::::::::       " },
                { "        '''':::: :EVILPRINCE2009:       " },
                { "                 ''''::::::::::::       " },
                { "                         ''''::::       " },
                { "                                        " },
                { "                                        " },
                { "                                        " }
            };

            return AsciiArt;
        }

        private static List<string> WindowsXI()
        {
            List<string> AsciiArt = new()
            {
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { "................ ................       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: :EVILPRINCE2009:       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { ":::::::::::::::: ::::::::::::::::       " },
                { "                                        " },
                { "                                        " },
                { "                                        " }
            };

            return AsciiArt;
        }
    }
}