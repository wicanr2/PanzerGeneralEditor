using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGEQReader
{
	partial class PanzerGeneral_UNIT {
		private string get_type() {
			string unitType;
			switch (_type) {
				case 0x00:
					unitType = "步兵";
					break;
				case 0x01:
					unitType = "坦克";
					break;
				case 0x04:
					unitType = "大砲或自走砲";
					break;
				case 0x08:
					unitType = "戰鬥機";
					break;
				case 0x09:
					unitType = "轟炸機";
					break;
				case 0x0A:
					unitType = "同溫層轟炸機";
					break;
				default:
					unitType = "未知";
					break;

			}
			return unitType;
		}
		private string get_target_type() {
			string r;
			switch (_target_type) {
				case 0x00:
					r = "soft";
					break;
				case 0x01:
					r = "hard";
					break;
				case 0x02:
					r = "plane";
					break;
				default:
					r = "unknow";
					break;
			}
			return r;
		}
		private int get_cost() {
			int r = 0;
			r = (int) _cost;
			r = r * 12;
			return r;
		}
		private int get_year(byte y) {
			int r = (int) y;
			r += 1900;
			return r;
		}
		public void parse() {
			Array.Copy( total, 0, name, 0, 20 );
			_type = total[20];
			_soft_attack = total[21];
			_hard_attack = total[22];
			_air_attack = total[23];
			_naval_attack = total[24];
			_ground_defense = total[25];
			_air_defense = total[26];
			_close_defense = total[27];
			_target_type = total[28];
			_level_bomer_pression = total[29];
			unknown1 = total[30];
			_initiative = total[31];
			_range = total[32];
			_spotting = total[33];
            unknown2 = total[34];
			_move_type = total[35];
			_movement = total[36];
			_fuel = total[37];
			_ammunition = total[38];
			Array.Copy( total, 39, unknown3, 0, 2 );
			_cost = total[41];
			_little_icon = total[42];
			unknown4 = total[43];
			_combat_animation = total[44];
			unknown5 = total[45];
			_present_month = total[46];
			_present_year = total[47];
			_non_present_year = total[48];
			delimiter = total[49];
		}
		public void write_back() {
			Array.Copy( name, 0, total, 0, 20 );
			total[21] = _soft_attack;
			total[22] = _hard_attack;
			total[23] = _air_attack;
			total[24] = _naval_attack;
			total[25] = _ground_defense;
			total[26] = _air_defense;
			total[27] = _close_defense;

			total[29] = _level_bomer_pression;

			total[31] = _initiative;
			total[32] = _range;
			total[33] = _spotting;


			total[36] = _movement;
			total[37] = _fuel;
			total[38] = _ammunition;

			total[41] = _cost;
		}
		public void simple_list() {
			System.Text.ASCIIEncoding enc = new System.Text.ASCIIEncoding();
			Console.WriteLine( "名稱 \t\t= {0}", enc.GetString( name ) );
			Console.WriteLine( "Type \t\t= {0}", get_type() );
			Console.WriteLine( "soft attack \t= {0}", _soft_attack );
			Console.WriteLine( "hard attack \t= {0}", _hard_attack );
			Console.WriteLine( "air  attack \t= {0}", _air_attack );
			Console.WriteLine( "naval attack \t= {0}", _naval_attack );
			Console.WriteLine( "ground def \t= {0}", _ground_defense );
			Console.WriteLine( "air def \t= {0}", _air_defense );
			Console.WriteLine( "close def \t= {0}", _close_defense );
			Console.WriteLine( "target \t\t= {0}", get_target_type() );
			Console.WriteLine( "pression \t= {0}", _level_bomer_pression );
			Console.WriteLine( "initiative \t= {0}", _initiative );
			Console.WriteLine( "range \t\t= {0}", _range );
			Console.WriteLine( "spotting \t= {0}", _spotting );
			Console.WriteLine( "move_type \t= {0}", _move_type );
			Console.WriteLine( "movement \t= {0}", _movement );
			Console.WriteLine( "fuel \t\t= {0}", _fuel );
			Console.WriteLine( "ammunition \t= {0}", _ammunition );
			Console.WriteLine( "cost \t\t= {0}", get_cost() );
			Console.WriteLine( "start year \t= {0}", get_year( _present_year ) );
			Console.WriteLine( "end year \t= {0}\n", get_year( _non_present_year ) );
		}
	}
}
