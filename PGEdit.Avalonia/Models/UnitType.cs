namespace PGEdit.Avalonia.Models;

/// <summary>
/// PANZEQUP.EQP byte offset 20 的 unit type (00–11).
/// 名稱對齊 pgeq_reader.get_type_name (中文化版本)。
/// </summary>
public enum UnitType : byte
{
    Infantry = 0x00,        // 步兵團
    Tank = 0x01,            // 戰車
    Recon = 0x02,           // 偵查車
    AntiTank = 0x03,        // 反戰車砲
    Artillery = 0x04,       // 砲兵
    AntiAircraft = 0x05,    // 防空砲 (自走)
    AirDefense = 0x06,      // 防空高射砲 (固定)
    Fort = 0x07,            // 碉堡
    Fighter = 0x08,         // 戰鬥機
    Bomber = 0x09,          // 轟炸機
    LevelBomber = 0x0A,     // 同溫層轟炸機
    Submarine = 0x0B,       // 潛水艇
    Destroyer = 0x0C,       // 驅逐艦
    Battleship = 0x0D,      // 主力艦
    Carrier = 0x0E,         // 巡洋艦
    Truck = 0x0F,           // 裝甲車 / 卡車
    AirTransport = 0x10,    // 運輸機
    SeaTransport = 0x11,    // 運輸船
}

public enum MoveType : byte
{
    Tracked = 0,            // 履帶
    HalfTracked = 1,        // 半履帶
    Wheeled = 2,            // 輪胎
    Leg = 3,                // 徒步
    Towed = 4,              // 拖曳
    Air = 5,                // 飛行
    Sea = 6,                // 航行
    AllTerrain = 7,         // 全地形
}

public static class UnitTypeRegistry
{
    public static string DisplayName(UnitType t) => t switch
    {
        UnitType.Infantry => "步兵團",
        UnitType.Tank => "戰車",
        UnitType.Recon => "偵查車",
        UnitType.AntiTank => "反戰車砲",
        UnitType.Artillery => "砲兵",
        UnitType.AntiAircraft => "防空砲",
        UnitType.AirDefense => "防空高射砲",
        UnitType.Fort => "碉堡",
        UnitType.Fighter => "戰鬥機",
        UnitType.Bomber => "轟炸機",
        UnitType.LevelBomber => "同溫層轟炸機",
        UnitType.Submarine => "潛水艇",
        UnitType.Destroyer => "驅逐艦",
        UnitType.Battleship => "主力艦",
        UnitType.Carrier => "巡洋艦",
        UnitType.Truck => "裝甲車",
        UnitType.AirTransport => "運輸機",
        UnitType.SeaTransport => "運輸船",
        _ => "未知型態",
    };

    /// <summary>
    /// 用漢字當 glyph;Noto Sans TC 100% 含這些字,不會 fallback 到方塊 X。
    /// 後續可改用 UnitIconProvider 從 Assets/units/&lt;id&gt;.png 載入真實圖示。
    /// </summary>
    public static string Glyph(UnitType t) => t switch
    {
        UnitType.Infantry => "步",
        UnitType.Tank => "甲",
        UnitType.Recon => "偵",
        UnitType.AntiTank => "反",
        UnitType.Artillery => "砲",
        UnitType.AntiAircraft => "防",
        UnitType.AirDefense => "高",
        UnitType.Fort => "堡",
        UnitType.Fighter => "鬥",
        UnitType.Bomber => "炸",
        UnitType.LevelBomber => "層",
        UnitType.Submarine => "潛",
        UnitType.Destroyer => "驅",
        UnitType.Battleship => "艦",
        UnitType.Carrier => "巡",
        UnitType.Truck => "車",
        UnitType.AirTransport => "運",
        UnitType.SeaTransport => "船",
        _ => "?",
    };

    public static string Category(UnitType t) => t switch
    {
        UnitType.Infantry or UnitType.AntiTank or UnitType.Artillery or
        UnitType.AntiAircraft or UnitType.AirDefense or UnitType.Fort => "地面/步炮",
        UnitType.Tank or UnitType.Recon or UnitType.Truck => "裝甲",
        UnitType.Fighter or UnitType.Bomber or UnitType.LevelBomber or
        UnitType.AirTransport => "空軍",
        UnitType.Submarine or UnitType.Destroyer or UnitType.Battleship or
        UnitType.Carrier or UnitType.SeaTransport => "海軍",
        _ => "其他",
    };

    public static string MoveTypeName(MoveType m) => m switch
    {
        MoveType.Tracked => "履帶",
        MoveType.HalfTracked => "半履帶",
        MoveType.Wheeled => "輪胎",
        MoveType.Leg => "徒步",
        MoveType.Towed => "拖曳",
        MoveType.Air => "飛行",
        MoveType.Sea => "航行",
        MoveType.AllTerrain => "全地形",
        _ => "未知",
    };
}
