namespace PGEdit.Avalonia.Models;

/// <summary>
/// 各欄位的硬上限 (PANZEQUP.EQP byte ⇒ 0..255) 與「不破壞遊戲樂趣」的軟上限,
/// 來自原 PGEdit edit_init.cs create_object_message 的 tooltip 文字。
/// </summary>
public static class StatBounds
{
    public const int HardMaxByte = 255;
    public const int CostHardMax = 3060;          // 12 * 255
    public const int CostStep = 12;

    public static (int Soft, int Hard) Range(string field) => field switch
    {
        nameof(UnitDto.SoftAttack) => (25, 255),
        nameof(UnitDto.HardAttack) => (25, 255),
        nameof(UnitDto.AirAttack) => (25, 255),
        nameof(UnitDto.NavalAttack) => (25, 255),
        nameof(UnitDto.GroundDefense) => (25, 255),
        nameof(UnitDto.AirDefense) => (25, 255),
        nameof(UnitDto.CloseDefense) => (25, 255),
        nameof(UnitDto.Initiative) => (25, 255),
        nameof(UnitDto.Range) => (25, 255),
        nameof(UnitDto.Spotting) => (5, 255),
        nameof(UnitDto.Movement) => (10, 255),
        nameof(UnitDto.Fuel) => (255, 255),
        nameof(UnitDto.Ammunition) => (255, 255),
        nameof(UnitDto.LevelPression) => (50, 255),
        nameof(UnitDto.Cost) => (3060, 3060),
        _ => (255, 255),
    };

    public static string? Hint(string field) => field switch
    {
        nameof(UnitDto.SoftAttack) => "普通攻擊。建議 ≤ 25 以維持平衡。",
        nameof(UnitDto.HardAttack) => "裝甲攻擊。建議 ≤ 25 以維持平衡。",
        nameof(UnitDto.AirAttack) => "對空攻擊。建議 ≤ 25 以維持平衡。",
        nameof(UnitDto.NavalAttack) => "對海攻擊。建議 ≤ 25 以維持平衡。",
        nameof(UnitDto.GroundDefense) => "對地防禦。建議 ≤ 25。",
        nameof(UnitDto.AirDefense) => "對空防禦。建議 ≤ 25。",
        nameof(UnitDto.CloseDefense) => "近戰防禦。建議 ≤ 25。",
        nameof(UnitDto.Initiative) => "攻擊啟動值,影響先手判定。",
        nameof(UnitDto.Range) => "攻擊範圍。建議 ≤ 25。",
        nameof(UnitDto.Spotting) => "偵查範圍。建議 ≤ 5。",
        nameof(UnitDto.Movement) => "移動點數。建議 ≤ 10。",
        nameof(UnitDto.Fuel) => "油量,0 = 無限。",
        nameof(UnitDto.Ammunition) => "彈藥量,0 = 無限。",
        nameof(UnitDto.Cost) => "單位購買價格。必為 12 的倍數,非倍數會自動調整。",
        nameof(UnitDto.LevelPression) => "同溫層轟炸機壓制力。> 50 後效果與 50 相同。",
        nameof(UnitDto.Name) => "單位名稱,最大 20 bytes (中文約 10 字)。",
        _ => null,
    };
}
