using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PGEQReader;
namespace PGEQConsole {
  class Program {
    static void Main(string[] args) {
      pgeq_reader pg = new pgeq_reader();
      pg.read_equ_file();
      pg.list_i( 5 );
      pg.list_i( 6 );
      pg.list_i( 3 );
      pg.list_i( 0 );
      pg.set_attack( 0, 3, 3, -1, -1 );
      pg.set_unit_name( 0, "BF109e Anr100" );
      pg.write_back( 0 );
      pg.list_i( 0 );
      Console.WriteLine( "讀取檔案 {0}",
              pg.get_file_name() );
      Console.WriteLine( "總共單位數量 = {0}",
              pg.test() );

    }
  }
}
