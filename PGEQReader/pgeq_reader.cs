using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PGEQReader {

	public class pgeq_reader {
		private string equipement_file = "PANZEQUP.EQP";
		private string default_file;
		unit_list pg_unit_list = new unit_list();
		int init = 0;
		public pgeq_reader() {
		}
		~pgeq_reader() {
		}
		public void set_equ_file(string f) {
			default_file = f;
		}
		public string get_file_name() {
			return default_file;
		}
		public void read_equ_file() {
			if (init > 0) return;
            
			if (default_file == null)
				default_file = equipement_file;

			FileStream in_equ = File.Open( default_file, FileMode.Open );
			BinaryReader br = new BinaryReader( in_equ );
			byte[] tmp = null;
			int pos = 0;
			/*Console.WriteLine(
			  "{0} 長度 {1}",
			  equipement_file, br.BaseStream.Length
			  );*/
			br.BaseStream.Seek( 52, SeekOrigin.Begin );

			while (true) {
				pos = (int) br.BaseStream.Position;
				tmp = br.ReadBytes( 50 );

				if (tmp.Length != 50) {
					//Console.WriteLine( "the tmp length = {0}", tmp.Length );
					break;
				}
				pg_unit_list.add_unit_to_pool( pos, tmp );
			}
			br.Close();
			in_equ.Close();
			init = 1;
		}
		public void Read_Test() {
			read_equ_file();
			pg_unit_list.list_top_5();
			pg_unit_list.list_last_5();
		}
		public int test() {
			return pg_unit_list.get_pool_count();
		}
		public int get_count() {
			return pg_unit_list.get_pool_count();
		}

		public void get_attack(int i, ref int s, ref int h, ref int a, ref int n) {
			s = (int) pg_unit_list.get_soft_attack( i );
			h = (int) pg_unit_list.get_hard_attack( i );
			a = (int) pg_unit_list.get_air_attack( i );
			n = (int) pg_unit_list.get_naval_attack( i );
		}
		public void set_attack(int i, int s, int h, int a, int n) {
			pg_unit_list.set_soft_attack( i, s );
			pg_unit_list.set_hard_attack( i, h );
			pg_unit_list.set_air_attack( i, a );
			pg_unit_list.set_naval_attack( i, n );
		}

		public string get_unit_name(int i) {
			return pg_unit_list.get_name( i );
		}
		public void set_unit_name(int i, string name) {
			pg_unit_list.set_name( i, name );
		}

		public void get_defense(int i, ref int g, ref int a, ref int c) {
			g = (int) pg_unit_list.get_ground_defense( i );
			a = (int) pg_unit_list.get_air_defense( i );
			c = (int) pg_unit_list.get_close_defense( i );
		}
		public void set_defense(int i, int g, int a, int c) {
			pg_unit_list.set_ground_defense( i, g );
			pg_unit_list.set_air_defense( i, a );
			pg_unit_list.set_close_defense( i, c );
		}
		public int get_initiative(int i) {
			return (int) pg_unit_list.get_initiative( i );
		}
		public void set_initiative(int i, int v) {
			pg_unit_list.set_initiative( i, v );
		}
		public int get_range(int i) {
			return (int) pg_unit_list.get_range( i );
		}
		public void set_range(int i, int v) {
			pg_unit_list.set_range( i, v );
		}
		public int get_spotting(int i) {
			return (int) pg_unit_list.get_spotting( i );
		}
		public void set_spotting(int i, int v) {
			pg_unit_list.set_spotting( i, v );
		}
		public int get_movement(int i) {
			return (int) pg_unit_list.get_movement( i );
		}
		public void set_movement(int i, int v) {
			pg_unit_list.set_movement( i, v );
		}
		public void get_fuel_ammo(int i, ref int f, ref int a) {
			f = (int) pg_unit_list.get_fuel( i );
			a = (int) pg_unit_list.get_ammunition( i );
		}
		public void set_fuel_ammo(int i, int f, int a) {
			pg_unit_list.set_fuel( i, f );
			pg_unit_list.set_ammunition( i, a );
		}
		public int get_cost(int i) {
			return (int) pg_unit_list.get_cost( i );
		}
		public void set_cost(int i, int v) {
			pg_unit_list.set_cost( i, v );
		}
		public int get_level_pression(int i) {
			return (int) pg_unit_list.get_level_pression( i );
		}
		public void set_level_pression(int i, int v) {
			pg_unit_list.set_level_pression( i, v );
		}

		public int get_type(int i) {
			return (int) pg_unit_list.get_type( i );
		}
		/* 00 = infantry,  步兵
		 * 01 = tank ,     裝甲
		 * 02 = recon ,    偵查
		 * 03 = anti-tank , 反裝甲
		 * 04 = artillery,  砲兵
		 * 05 = anti-aircraft  移動式防空砲
		 * 06 = air defense 防空砲
		 * 07 = Fort 碉堡
		 * 08 = fighter , 戰鬥機 
		 * 09 = bomber  轟炸機
		 * 0A = level bomber  同溫層轟炸機
		 * 0B = Submarine 潛水艇
		 * 0C = Destroyer 驅逐艦
		 * 0D = Battleship 戰艦
		 * 0E = Carrier 巡洋艦
		 * 0F = Truck 裝甲載具
		 * 10 = Transport(air) 運輸機
		 * 11 = Transport(sea) 運輸船
		 */
		public string get_type_name(int i) {
			switch (i) {
				case 0:
					return "步兵";
				case 1:
					return "裝甲";
				case 2:
					return "偵查";
				case 3:
					return "反裝甲";
				case 4:
					return "砲兵";
				case 5:
					return "移動式防空砲";
				case 6:
					return "防空砲";
				case 7:
					return "碉堡";
				case 8:
					return "戰鬥機";
				case 9:
					return "轟炸機";
				case 10:
					return "同溫層轟炸機";
				case 11:
					return "潛水艇";
				case 12:
					return "驅逐艦";
				case 13:
					return "戰艦";
				case 14:
					return "巡洋艦";
				case 15:
					return "裝甲載具";
				case 16:
					return "運輸機";
				case 17:
					return "運輸船";
				default:
					return "無此型態";

			}
		}

		public int get_move_type(int i) {
			return (int) pg_unit_list.get_move_type( i );
		}
		/*
		 * 00 = Tracked
		 * 01 = Half-Tracked
		 * 02 = Wheeled
		 * 03 = Leg
		 * 04 = Towed
		 * 05 = Air
		 * 06 = Sea
		 * 07 = All Terrain
		 */
		public void list_i(int i) {
			pg_unit_list.list_i( i );
		}
		public void write_back(int i) {
			int offset = 0;
			byte[] tmp = null;

			pg_unit_list.write_back( i );

			offset = pg_unit_list.get_offset( i );
			if (offset < 0) return;

			tmp = pg_unit_list.get_alldata( i );
			if (tmp.Length != 50) return;

			FileStream out_equ = File.Open( equipement_file,
			FileMode.Open );
			BinaryWriter bw = new BinaryWriter( out_equ );
			bw.BaseStream.Seek( offset, SeekOrigin.Begin );
			bw.Write( tmp, 0, 50 );
			bw.Close();
			out_equ.Close();
		}
	}
}
