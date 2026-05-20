using Avalonia.Media.Imaging;
using CommunityToolkit.Mvvm.ComponentModel;
using PGEdit.Avalonia.Models;
using PGEdit.Avalonia.Services;

namespace PGEdit.Avalonia.ViewModels;

/// <summary>
/// 一個 unit 的可編輯快照。所有屬性變動會 set IsDirty。
/// 切換到別的 unit 時 MainWindowViewModel 會重新 Load。
/// </summary>
public partial class UnitEditorViewModel : ObservableObject
{
    private bool _suspendDirty;

    [ObservableProperty] private int _index;
    [ObservableProperty] private string _name = string.Empty;
    [ObservableProperty] private UnitType _type;
    [ObservableProperty] private MoveType _moveType;

    [ObservableProperty] private int _softAttack;
    [ObservableProperty] private int _hardAttack;
    [ObservableProperty] private int _airAttack;
    [ObservableProperty] private int _navalAttack;

    [ObservableProperty] private int _groundDefense;
    [ObservableProperty] private int _airDefense;
    [ObservableProperty] private int _closeDefense;

    [ObservableProperty] private int _initiative;
    [ObservableProperty] private int _range;
    [ObservableProperty] private int _spotting;

    [ObservableProperty] private int _movement;
    [ObservableProperty] private int _fuel;
    [ObservableProperty] private int _ammunition;

    [ObservableProperty] private int _cost;
    [ObservableProperty] private int _levelPression;
    [ObservableProperty] private int _initForce;
    [ObservableProperty] private bool _isGroundUnit;

    [ObservableProperty] private int _unknown1;
    [ObservableProperty] private int _unknown4;
    [ObservableProperty] private int _unknown5;
    [ObservableProperty] private int _littleIcon;

    [ObservableProperty] private bool _isDirty;

    public string TypeGlyph => UnitTypeRegistry.Glyph(Type);
    public string TypeName => UnitTypeRegistry.DisplayName(Type);
    public string MoveTypeName => UnitTypeRegistry.MoveTypeName(MoveType);
    public Bitmap? IconBitmap => UnitIconProvider.GetByLittleIcon(LittleIcon);
    public bool HasIconBitmap => UnitIconProvider.HasLittleIcon(LittleIcon);

    public void Load(UnitDto u)
    {
        _suspendDirty = true;
        try
        {
            Index = u.Index;
            Name = u.Name;
            Type = u.Type;
            MoveType = u.MoveType;
            SoftAttack = u.SoftAttack;
            HardAttack = u.HardAttack;
            AirAttack = u.AirAttack;
            NavalAttack = u.NavalAttack;
            GroundDefense = u.GroundDefense;
            AirDefense = u.AirDefense;
            CloseDefense = u.CloseDefense;
            Initiative = u.Initiative;
            Range = u.Range;
            Spotting = u.Spotting;
            Movement = u.Movement;
            Fuel = u.Fuel;
            Ammunition = u.Ammunition;
            Cost = u.Cost;
            LevelPression = u.LevelPression;
            InitForce = u.InitForce;
            IsGroundUnit = u.IsGroundUnit;
            Unknown1 = u.Unknown1;
            Unknown4 = u.Unknown4;
            Unknown5 = u.Unknown5;
            LittleIcon = u.LittleIcon;
            IsDirty = false;
        }
        finally
        {
            _suspendDirty = false;
        }
        OnPropertyChanged(nameof(TypeGlyph));
        OnPropertyChanged(nameof(TypeName));
        OnPropertyChanged(nameof(MoveTypeName));
        OnPropertyChanged(nameof(IconBitmap));
        OnPropertyChanged(nameof(HasIconBitmap));
    }

    public UnitDto ToDto() => new()
    {
        Index = Index,
        Name = Name,
        Type = Type,
        MoveType = MoveType,
        SoftAttack = SoftAttack,
        HardAttack = HardAttack,
        AirAttack = AirAttack,
        NavalAttack = NavalAttack,
        GroundDefense = GroundDefense,
        AirDefense = AirDefense,
        CloseDefense = CloseDefense,
        Initiative = Initiative,
        Range = Range,
        Spotting = Spotting,
        Movement = Movement,
        Fuel = Fuel,
        Ammunition = Ammunition,
        Cost = Cost,
        LevelPression = LevelPression,
        InitForce = InitForce,
        IsGroundUnit = IsGroundUnit,
        Unknown1 = Unknown1,
        Unknown4 = Unknown4,
        Unknown5 = Unknown5,
        LittleIcon = LittleIcon,
    };

    partial void OnLittleIconChanged(int value)
    {
        OnPropertyChanged(nameof(IconBitmap));
        OnPropertyChanged(nameof(HasIconBitmap));
    }

    partial void OnNameChanged(string value) => MarkDirty();
    partial void OnSoftAttackChanged(int value) => MarkDirty();
    partial void OnHardAttackChanged(int value) => MarkDirty();
    partial void OnAirAttackChanged(int value) => MarkDirty();
    partial void OnNavalAttackChanged(int value) => MarkDirty();
    partial void OnGroundDefenseChanged(int value) => MarkDirty();
    partial void OnAirDefenseChanged(int value) => MarkDirty();
    partial void OnCloseDefenseChanged(int value) => MarkDirty();
    partial void OnInitiativeChanged(int value) => MarkDirty();
    partial void OnRangeChanged(int value) => MarkDirty();
    partial void OnSpottingChanged(int value) => MarkDirty();
    partial void OnMovementChanged(int value) => MarkDirty();
    partial void OnFuelChanged(int value) => MarkDirty();
    partial void OnAmmunitionChanged(int value) => MarkDirty();
    partial void OnCostChanged(int value) => MarkDirty();
    partial void OnLevelPressionChanged(int value) => MarkDirty();
    partial void OnInitForceChanged(int value) => MarkDirty();

    private void MarkDirty()
    {
        if (_suspendDirty) return;
        IsDirty = true;
    }
}
