#Pazner General Chinese Editor with Chinese Translation
* Editor can support "Panzer General DOS/WIN95", "Allied General".
* Panzer General Chinese Translation is used for WIN95 version

2016.10.18
 1. 完成大部分字型的調整, 更適合中文閱讀
 2. 新增調整字型過後的畫面

2016.10.16 15:00
 1. 完成單位名稱中文化

2016.10.16
 1. 中文化波蘭戰場地名
 2. Change encoding page from utf-8 to 950 in PGEdit
 3. 刪除 PG-Cht.exe 資源表無關的字串
 4. 部分單位名稱中文化

2016.10.14
Change Font from Arial to Tahoma for Chinese Version

#Demo
[![裝甲元帥中文版 波蘭戰役](http://img.youtube.com/vi/D3X3dRyF424/0.jpg)](http://www.youtube.com/watch?v=D3X3dRyF424 "裝甲元帥中文版 波蘭戰役")

#Note
* 0001A063H 視窗選單中文大小 預設09
* 0006072CH Dialog Title Font size
* 0007F752H Waiting Dialog Font Size 
* 000B9E71H Upgrade Window Detail Font Size 6A006A0A
* 000B9F3DH Upgrade Window Font Size 6A006A0A
* 000C09E4H 簡報 Dialog font size
* 000C4355H Information Window Font size
* 000C442BH Information Window Content Font size
* 000C8EDEH CAUSALITY line height 00
* 000C8EE0H CAUSALITY line height 0A
* 000C8FAAH CAUSALITY 傷亡表 字型 type 00
* 000C8FACH CAUSALITY 傷亡表 字型大小 0A
* 000CFA78H Status Bar font size
* 000F1348H game option font size
* 001023B3H PURCHASE UNIT 購買部隊 Detail Font Size
* 0010247FH PURCHASE UNIT 購買部隊字型大小  00 xx 0A
* 0015A750H BUTTON FONT SIZE

* Sd.Kfz. Sonderkraftfahrzeug "Special purpose vehicle" 
Sd.Kfz 101 = Panzer 1 (一號戰車)
Self-Protection Weapon = SPW 自保護武器
* Sd.Kfz. 6/2 (self-propelled 37 mm antiaircraft gun) 
  SdKfz 6/2 --> 37mm防空炮
* Sd.Kfz. 7/1 (self-propelled 20 mm quad antiaircraft gun) 翻譯為 20mm防空炮車
* Sd.Kfz. 10/4 (self-propelled 20 mm FlaK 30 antiaircraft gun) 翻譯為 20mm防空炮車38
* Sd.Kfz.SPW 250/1 (armored light halftrack) 翻譯為 輕半履帶車 or 輕型運兵車(SPW 250/1)
  - Sd.Kfz. 250/1 (light armored halftrack with communications gear)

* Sd.Kfz. 251 (medium armored halftrack) 翻譯為 中型運兵車 SPW 251/1
  - Sd.Kfz. 251/1 (medium armored halftrack with communications gear)

* PSW 德文為 Schwerer Panzerspähwagen(heavy armoured reconnaissance vehicle) 重型偵查車
* Sd.Kfz. 222 (Leichter Panzerspähwagen with 20 mm L/55 main gun)
  Leichter Panzerspähwagen 英文為 light armoured reconnaissance vehicle 輕裝偵查車
  PSW 222/4r 輕偵查車222 表示 4輪

  Sd.Kfz. 231 6-rad (Schwerer Panzerspähwagen (6 wheel) with 20 mm L/55 main gun) 
  PSW 231/6r 重偵查車231
  PSW 232/8r 重裝甲車232
  PSW 233/8r 重裝甲車233

  PSW 234/1-8r 重裝甲車234/1
  PSW 234/2-8r 重裝甲車234/2

* Pak Panzerabwehrkanone 反戰車砲
  3.7 35/36 Pak 3.7表示公分 35/36 表示設計年度

* le 表示 leichtes, nA表示 neuer Art 新風格
  Fk 表示 Feld Kanone 
  7.5 leFk 16nA 7.5 表公分 16應該表示編號

* leFH 表示 leichte Feldhaubitze "light field howitzer" 輕榴彈砲
  10.5 leFH 18 10.5輕榴彈砲  18應該表示編號

* sFH 表示 schwere Feldhaubitze heavy field howitzer
  15 sFH 18 15 重榴彈砲

* 17K18 K Kanone 加農砲(直射)
  17 K 18 表示 17公分(彈藥) 的加農砲

* Flak Flugabwehrkanone 表示高射炮
  2 FlaK38 (4) 表示 2公分的 四門的高射炮

* Opel 6700 Track 又名 Opel 6700 Opel Blitz 3,6 閃電卡車 蠻威的名字

* AF 應該是 Allied Force 的縮寫 拿掉全部的AF
* AD 全名應該是 Auxiliary Defense 所有AD都被拿掉了 

* AEC Armoured Car, Associated Equipment Company 這是公司名稱

* BA-10 BA-64 BA表示 Broneavtomobil 的縮寫 英文為 Armored Car
* BT 表示 Bystrokhodny tank, lit. "fast moving tank" or "high-speed tank"
  BT-5 翻譯為快速戰車5 or 高速戰車5

* SU 表示 Samokhodnaya ustanovka 自走砲之意
  SU-85 表示 85mm(砲彈長度) 的自走砲
  SU-85 在遊戲中屬於ATG所以翻譯為 85突擊砲
  SU-122 翻譯為 122自走砲

* KV 表示 Kliment Yefremovich Voroshilov 克利緬特·葉夫列莫維奇·伏羅希洛夫
  不翻譯

* ISU 表示 Iosif Stalin Samokhodnaya ustanovka 史達林的自走砲
  

#Installation
1. copy PGCht/PG-cht.exe into your {PANZER_GENERAL}/
2. copy PGCht/MAPNAMES.STR into your {PANZER_GENERAL}/DATA/
3. Panzer General Edit PGEdit/prebuilt/PGEdit.exe

裝甲元帥中文修改器 (Panzer General Chinese Editor)<br>
<img src="/images/screenshot7.png?raw=true" width="480" alt="裝甲元帥中文修改器" title="裝甲元帥中文修改器">

#Compliation
prerequisite: Visual Stduio 2012, .Net Framework 4.5

#Funny Limerick 
* 001BBE5CH - 001BBED4H
I am not Slappy the Lot Boy, despite my witty demeanor repeat NOT slappy Boy. We love Lot Boy.
* 001BD0D4 
General Slappy the Lotboy

#Author
Chun-Yu Wang (wicanr2@gmail.com)

#Chinese Translation ScreenShot
-儲存視窗<br>
 <img src="/images/screenshot8.png?raw=true" width="480" alt="儲存視窗" title="儲存視窗">

-簡報視窗<br>
 <img src="/images/screenshot9.png?raw=true" width="480" alt="簡報視窗" title="簡報視窗">

-中文遊戲選項列表 ( CHT Game Selection Options )<br>
 <img src="/images/screenshot1-1.png?raw=true" width="480" alt="中文遊戲選項列表" title="中文遊戲選項列表">
 <img src="/images/screenshot1.png?raw=true" width="480" alt="中文遊戲選項列表" title="中文遊戲選項列表">

-購買部隊 (Purchase Unit with Chinese Translation)<br>
 <img src="/images/screenshot2-1.png?raw=true" width="480" alt="購買部隊" title="購買部隊">
 <img src="/images/screenshot2.png?raw=true" width="480" alt="購買部隊" title="購買部隊">

-遊戲畫面 ( Strategy Window )<br>
 <img src="/images/screenshot3-1.png?raw=true" width="480" alt="遊戲畫面" title="遊戲畫面">
 <img src="/images/screenshot3.png?raw=true" width="480" alt="遊戲畫面" title="遊戲畫面">

-ORG TABLE<br>
 <img src="/images/screenshot4.png?raw=true" width="240" alt="ORG TABLE" title="ORG TABLE">

-部隊檢視 ( Review Unit )<br>
 <img src="/images/screenshot5-1.png?raw=true" width="480" alt="部隊檢視" title="部隊檢視">
 <img src="/images/screenshot5.png?raw=true" width="480" alt="部隊檢視" title="部隊檢視">

-戰場模式選單 ( Play Scenario )<br>
 <img src="/images/screenshot6-1.png?raw=true" width="480" alt="戰場模式選單" title="戰場模式選單">
 <img src="/images/screenshot6.png?raw=true" width="480" alt="戰場模式選單" title="戰場模式選單">

