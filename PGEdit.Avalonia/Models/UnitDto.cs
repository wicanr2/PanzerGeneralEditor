namespace PGEdit.Avalonia.Models;

/// <summary>
/// 一筆從 PANZEQUP.EQP 解出的單位資料 (用於 ViewModel ↔ Service 間傳遞)。
/// 全部 byte 在 0..255,Cost 為 12 的倍數 (max 3060)。
/// </summary>
public sealed record UnitDto
{
    public int Index { get; init; }
    public string Name { get; init; } = string.Empty;
    public UnitType Type { get; init; }
    public MoveType MoveType { get; init; }

    public int SoftAttack { get; init; }
    public int HardAttack { get; init; }
    public int AirAttack { get; init; }
    public int NavalAttack { get; init; }

    public int GroundDefense { get; init; }
    public int AirDefense { get; init; }
    public int CloseDefense { get; init; }

    public int Initiative { get; init; }
    public int Range { get; init; }
    public int Spotting { get; init; }

    public int Movement { get; init; }
    public int Fuel { get; init; }
    public int Ammunition { get; init; }

    public int Cost { get; init; }              // 必為 12 的倍數
    public int LevelPression { get; init; }     // 同溫層轟炸機壓制力
    public int InitForce { get; init; }
    public bool IsGroundUnit { get; init; }

    public int Unknown1 { get; init; }
    public int Unknown4 { get; init; }
    public int Unknown5 { get; init; }

    /// <summary>
    /// EQP byte offset 42; index into TILEART.DAT u### sprite.
    /// 例如 BF109e._little_icon = 1 → 顯示 u001.png (戰機 silhouette)。
    /// </summary>
    public int LittleIcon { get; init; }
}
