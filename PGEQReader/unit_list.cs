using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGEQReader
{
	class unit_list {
		class unit_vector {
			public PanzerGeneral_UNIT pg_unit = new PanzerGeneral_UNIT();
			public int offset = 0;
		}
		private unit_vector[] unit_pool = new unit_vector[500];
		private int pool_max_cnt = 500;
		private int pool_used = 0;

		public int get_pool_count() {
			return pool_used;
		}
		public void add_unit_to_pool(int offset, byte[] u) {
			if (u.Length != 50) return;
			if (pool_used >= pool_max_cnt - 1) return;

			unit_pool[pool_used] = new unit_vector();
			unit_pool[pool_used].offset = offset;
			PanzerGeneral_UNIT pgu = unit_pool[pool_used].pg_unit;
			Array.Copy( u, 0, pgu.total, 0, 50 );
			pgu.parse();
			pool_used++;

		}
		public void list_top_5() {
			int i = 0, j = 0;
			PanzerGeneral_UNIT pgu;

			if (pool_used > 5) {
				j = 5;
			} else {
				j = pool_used;
			}
			for (i = 0 ; i < j ; i++) {
				pgu = unit_pool[i].pg_unit;
				pgu.simple_list();
			}
		}
		public void list_last_5() {
			int i = 0, j = 0;
			PanzerGeneral_UNIT pgu;

			if (pool_used > 5) {
				j = 5;
			} else {
				j = pool_used;
			}
			for (i = pool_used - j ; i < pool_used ; i++) {
				pgu = unit_pool[i].pg_unit;
				pgu.simple_list();
			}
		}
		public void list_i(int i) {
			PanzerGeneral_UNIT pgu;

			if (i < 0 || i > pool_used) return;
			pgu = unit_pool[i].pg_unit;
			Console.WriteLine( "offset = {0}", unit_pool[i].offset );
			pgu.simple_list();

		}

		/* 設定參數用的 function */
		public void set_name(int i, string name) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			byte[] tmp;
			int size = 0;
			pgu = unit_pool[i].pg_unit;
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			tmp = enc.GetBytes( name );
			size = tmp.Length;
			if (size >= 18) size = 18;
			//只有 copy 前面 18個字
			Array.Copy( tmp, 0, pgu.name, 0, size );
		}
		public void set_soft_attack(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._soft_attack = (byte) v;
		}
		public void set_hard_attack(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._hard_attack = (byte) v;
		}
		public void set_air_attack(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._air_attack = (byte) v;
		}
		public void set_naval_attack(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._naval_attack = (byte) v;
		}
		public void set_ground_defense(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._ground_defense = (byte) v;
		}
		public void set_air_defense(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._air_defense = (byte) v;
		}
		public void set_close_defense(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._close_defense = (byte) v;
		}
		public void set_initiative(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._initiative = (byte) v;
		}
		public void set_range(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._range = (byte) v;
		}
		public void set_spotting(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._spotting = (byte) v;
		}
		public void set_movement(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._movement = (byte) v;
		}
		public void set_fuel(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._fuel = (byte) v;
		}
		public void set_ammunition(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._ammunition = (byte) v;
		}
		public void set_level_pression(int i, int v) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu._level_bomer_pression = (byte) v;
		}
		public void set_cost(int i, int v) {
			int x = 0, y = 0;
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			y = v % 12;
			x = ( v - y ) / 12;
			if (y > 0) x++;
			pgu._cost = (byte) x;
		}
		public void write_back(int i) {
			if (i < 0 || i > pool_used) return;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			pgu.write_back();
		}
		public int get_offset(int i) {
			if (i < 0 || i > pool_used) return -1;
			return unit_pool[i].offset;
		}
		public byte[] get_alldata(int i) {
			if (i < 0 || i > pool_used) return null;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu.total;
		}

		public string get_name(int i) {
			if (i < 0 || i > pool_used) return "not existed";
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			return enc.GetString( pgu.name );
		}
		public byte get_soft_attack(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._soft_attack;
		}
		public byte get_hard_attack(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._hard_attack;
		}
		public byte get_air_attack(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._air_attack;
		}
		public byte get_naval_attack(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._naval_attack;
		}
		public byte get_ground_defense(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._ground_defense;
		}
		public byte get_air_defense(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._air_defense;
		}
		public byte get_close_defense(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._close_defense;
		}
		public byte get_initiative(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._initiative;
		}
		public byte get_range(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._range;
		}
		public byte get_spotting(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._spotting;
		}
		public byte get_movement(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._movement;
		}
		public byte get_fuel(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._fuel;
		}
		public byte get_ammunition(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._ammunition;
		}
		public byte get_level_pression(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._level_bomer_pression;
		}
		public int get_cost(int i) {
			int x = 0;
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			x = pgu._cost;
			x = x * 12;
			return x;
		}
		public byte get_type(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._type;
		}
		public byte get_move_type(int i) {
			if (i < 0 || i > pool_used) return 0;
			PanzerGeneral_UNIT pgu;
			pgu = unit_pool[i].pg_unit;
			return pgu._move_type;
		}
	}
}
