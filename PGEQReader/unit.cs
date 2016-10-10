using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PGEQReader
{
	// PANZEQQUP 前兩個 BYTE 為 部隊總量SIZE 
	// 
	partial class PanzerGeneral_UNIT {
		//50;
		public byte[] total = new byte[50];

		//0~19 , size 20
		public byte[] name = new byte[20];

		/* 00 = infantry,  步兵
		 * 01 = tank ,     裝甲
		 * 02 = recon ,    偵查
		 * 03 = anti-tank , 反裝甲
		 * 04 = artillery,  砲兵
		 * 05 = anti-aircraft  防空砲
		 * 06 = air defense 防砲砲
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
		public byte _type;// pos 20 , size 1  

		public byte _soft_attack;
		public byte _hard_attack;
		public byte _air_attack;
		public byte _naval_attack;
		public byte _ground_defense;
		public byte _air_defense;
		public byte _close_defense;

		// size = 3
		// 00 = soft 01 = hard 02 = plane
		byte _target_type;
		public byte _level_bomer_pression;
		// level bomber 的壓制力
		public byte unknown1;

		public byte _initiative;
		public byte _range;
		public byte _spotting;


		public byte ground_unit; // sea ? cover 
		/* 飛機都有把上述的byte = 1*/

		/*
			00 = tracked , 01 = half-tracked ,
			03 = leg , 05 = air , 06 = sea,
		 *  07 = all terrain
		 */
		public byte _move_type;
		public byte _movement;
		public byte _fuel;
		public byte _ammunition;

		// size = 2 0a 06
		public byte init_force;
    public byte unknown3;
		public byte _cost; // 12 為基數 ex 1c = 28 cost = 28 * 12 = 336
    public byte _little_icon;
    public byte unknown4;
    public byte _combat_animation;
    public byte unknown5;
    // size = 3
    public byte _present_month;// 登場月份
    public byte _present_year;// 登場年份
    public byte _non_present_year; // 結束使用年份  

    public byte transport_type;
	}
}
