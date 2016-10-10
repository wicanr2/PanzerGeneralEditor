using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PGEQReader;
using System.Windows.Forms;

namespace PanzerGeneralEdit {
  public class Object_Message {
    public string object_name;
    public string message;
    public Object_Message() {
      object_name = "";
      message = "";
    }
  }
  partial class PGEditForm {
    pgeq_reader pg = new pgeq_reader();
    List<Object_Message> obj_match = new List<Object_Message>();
    int max_count = 0;
    int cur_i = 0;
    void init_the_reader(string fname) {
      pg.set_equ_file( fname );
      pg.read_equ_file();
      max_count = pg.get_count();
      cur_i = 0;
      fill_textbox();
      fill_listbox();
      lb_unit.SelectedIndex = cur_i;
    }
    void change_to_next() {
      cur_i = ( cur_i + 1 ) % max_count;
      lb_unit.SelectedIndex = cur_i;
      fill_textbox();
    }
    void change_to_prev() {
      cur_i--;
      if (cur_i < 0) cur_i = max_count - 1;
      lb_unit.SelectedIndex = cur_i;
      fill_textbox();
    }
    private string[] move_type_str = new string[] {
      "履帶", "半履帶", "輪胎", "徒步", "拖曳", "飛行", "航行", "全地形"
    };
    void fill_textbox() {
      int s = 0, h = 0, a = 0, n = 0;
      int g_def = 0, a_def = 0, c_def = 0;
      int initiative = 0, range = 0, spotting = 0;
      int move = 0, fuel = 0, ammo = 0;
      int cost = 0, pression = 0;
      int unknown1 = 0, ground_unit = 0, init_force = 0, unknown4 = 0, unknown5 = 0;

      string name;
      name = pg.get_unit_name( cur_i );
      pg.get_attack( cur_i, ref s, ref h, ref a, ref n );
      pg.get_defense( cur_i, ref g_def, ref a_def, ref c_def );
      initiative = pg.get_initiative( cur_i );
      range = pg.get_range( cur_i );
      spotting = pg.get_spotting( cur_i );
      move = pg.get_movement( cur_i );
      pg.get_fuel_ammo( cur_i, ref fuel, ref ammo );
      cost = pg.get_cost( cur_i );
      pression = pg.get_level_pression( cur_i );
      unknown1 = pg.get_unknown1(cur_i);
      ground_unit = pg.get_ground_unit(cur_i);
      init_force = pg.get_init_force(cur_i);
      unknown4 = pg.get_unknown4(cur_i);
      unknown5 = pg.get_unknown5(cur_i);

      tb_name.Text = name;
      tb_soft_atk.Text = s.ToString();
      tb_hard_atk.Text = h.ToString();
      tb_air_atk.Text = a.ToString();
      tb_nav_atk.Text = n.ToString();
      tb_gnd_def.Text = g_def.ToString();
      tb_air_def.Text = a_def.ToString();
      tb_close_def.Text = c_def.ToString();
      tb_initiative.Text = initiative.ToString();
      tb_range.Text = range.ToString();
      tb_spotting.Text = spotting.ToString();
      tb_movement.Text = move.ToString();
      tb_fuel.Text = fuel.ToString();
      tb_ammo.Text = ammo.ToString();
      tb_cost.Text = cost.ToString();
      tb_level_pression.Text = pression.ToString();
      tb_unknown1.Text = unknown1.ToString();
      if ( ground_unit == 0 ) {
        tb_ground_unit.Text = "是"; 
      } else {
        tb_ground_unit.Text = "否"; 
      }
      tb_init_force.Text = init_force.ToString();
      tb_unknown4.Text = unknown4.ToString();
      tb_unknown5.Text = unknown5.ToString();

      int type = pg.get_type( cur_i );

      tb_type.Text = pg.get_type_name( type );
      store_button.Enabled = false;
      /*
         if (type == 10 || type == 9) {
         tb_level_pression.Enabled = true;
         } else {
         tb_level_pression.Enabled = false;
         }
         */
      tb_level_pression.Enabled = true;

      int move_type = pg.get_move_type( cur_i );
      if ( move_type >= 0 && move_type <= 7 ) { 
        tb_move_type.Text =move_type_str[move_type]; 
      } else {
        tb_move_type.Text ="未知";
      }
    }
    void fill_listbox() {
      lb_unit.Items.Clear();
      int i = 0;
      for (i = 0 ; i < max_count ; i++) {
        lb_unit.Items.Add( pg.get_unit_name( i ) );
      }
    }
    void change_unit(int i) {
      cur_i = i;
      fill_textbox();
    }
    void apply_modify() {

      pg.set_unit_name( cur_i, tb_name.Text );


      int s = 0, h = 0, a = 0, n = 0;
      s = Convert.ToInt32( tb_soft_atk.Text );
      h = Convert.ToInt32( tb_hard_atk.Text );
      a = Convert.ToInt32( tb_air_atk.Text );
      n = Convert.ToInt32( tb_nav_atk.Text );
      pg.set_attack( cur_i, s, h, a, n );

      int g_def = 0, a_def = 0, c_def = 0;
      g_def = Convert.ToInt32( tb_gnd_def.Text );
      a_def = Convert.ToInt32( tb_air_def.Text );
      c_def = Convert.ToInt32( tb_close_def.Text );
      pg.set_defense( cur_i, g_def, a_def, c_def );

      int initiative = 0, range = 0, spotting = 0;
      initiative = Convert.ToInt32( tb_initiative.Text );
      range = Convert.ToInt32( tb_range.Text );
      spotting = Convert.ToInt32( tb_spotting.Text );
      pg.set_initiative( cur_i, initiative );
      pg.set_range( cur_i, range );
      pg.set_spotting( cur_i, spotting );

      int move = 0, fuel = 0, ammo = 0;
      move = Convert.ToInt32( tb_movement.Text );
      fuel = Convert.ToInt32( tb_fuel.Text );
      ammo = Convert.ToInt32( tb_ammo.Text );
      pg.set_movement( cur_i, move );
      pg.set_fuel_ammo( cur_i, fuel, ammo );

      int cost = 0, pression = 0;
      cost = Convert.ToInt32( tb_cost.Text );
      pression = Convert.ToInt32( tb_level_pression.Text );
      pg.set_cost( cur_i, cost );
      pg.set_level_pression( cur_i, pression );

      int init_force = 0;
      init_force = Convert.ToInt32(tb_init_force.Text);
      pg.set_init_force(cur_i,init_force);

      pg.write_back( cur_i );


    }
    // GUI object management
    void create_object_message() {
      Object_Message tmp;
      tmp = new Object_Message();
      tmp.object_name = tb_name.Name;
      tmp.message = "名稱長度最大18 bytes(中文等於九個字";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_soft_atk.Name;
      tmp.message = "普通攻擊 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_hard_atk.Name;
      tmp.message = "裝甲攻擊 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_air_atk.Name;
      tmp.message = "對空攻擊 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_nav_atk.Name;
      tmp.message = "對海攻擊 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp ); //5

      tmp = new Object_Message();
      tmp.object_name = tb_air_def.Name;
      tmp.message = "對空防禦 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_range.Name;
      tmp.message = "攻擊範圍 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_initiative.Name;
      tmp.message = "攻擊啟動值 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_close_def.Name;
      tmp.message = "近戰防禦 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_gnd_def.Name;
      tmp.message = "對地防禦 最大值255(建議最大值25,避免影響遊戲樂趣)";
      obj_match.Add( tmp ); //10

      tmp = new Object_Message();
      tmp.object_name = tb_fuel.Name;
      tmp.message = "油量 最大值255";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_movement.Name;
      tmp.message = "移動量 最大值255(建議最大值10,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_spotting.Name;
      tmp.message = "偵查範圍 最大值255(建議最大值5,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_ammo.Name;
      tmp.message = "彈藥量 最大值255";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_move_type.Name;
      tmp.message = "移動型態 最大值255(建議最大值15,避免影響遊戲樂趣)";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_cost.Name;
      tmp.message = "價格 最大值3060, 注意!只能輸入12的倍數, 輸入的數值非12倍數時將會自動調整";
      obj_match.Add( tmp );

      tmp = new Object_Message();
      tmp.object_name = tb_level_pression.Name;
      tmp.message = "同溫層轟炸機壓制力 最大值255(建議不要超過50," +
        "超過後轟炸效果相同 [當該值=50時 被轟炸的目標 90%的彈藥會消失] )";
      obj_match.Add( tmp );
    }
    void proc_mouse_hover(object sender) {
      if (sender is TextBox) {
        TextBox x = (TextBox) sender;
        foreach (Object_Message tmp in obj_match) {
          if (tmp.object_name == x.Name) {
            toolStripStatusLabel1.Text = tmp.message;
            break;
          }
        }
      }
    }//end of proc_mouse_hover
    void proc_mouse_leave(object sender) {
      if (sender is TextBox) {
        TextBox x = (TextBox) sender;
        foreach (Object_Message tmp in obj_match) {
          if (tmp.object_name == x.Name) {
            if (!x.Focused) {
              toolStripStatusLabel1.Text = "";
              break;
            }
          }
        }

      } else {
        toolStripStatusLabel1.Text = "";
      }
    }//end oif proce mouse_leave
  }
}
