using System;
using System.Collections.Generic;
using PGEdit.Avalonia.Models;
using PGEQReader;

namespace PGEdit.Avalonia.Services;

/// <summary>
/// 包裝原 PGEQReader.pgeq_reader,把 ref int 一堆 getter/setter 變成 UnitDto 進出。
/// 寫回時走 single-unit write_back,避免一次重寫整個檔案。
/// </summary>
public sealed class EquipmentFileService
{
    private readonly pgeq_reader _reader = new();
    private string? _path;
    private bool _initialised;

    public string? FilePath => _path;
    public bool IsLoaded => _initialised;

    public IReadOnlyList<UnitDto> Open(string path)
    {
        _reader.set_equ_file(path);
        _reader.read_equ_file();
        _path = path;
        _initialised = true;
        return ReadAll();
    }

    public IReadOnlyList<UnitDto> ReadAll()
    {
        var n = _reader.get_count();
        var list = new List<UnitDto>(n);
        for (var i = 0; i < n; i++)
            list.Add(ReadOne(i));
        return list;
    }

    public UnitDto ReadOne(int i)
    {
        int s = 0, h = 0, a = 0, n = 0;
        int gd = 0, ad = 0, cd = 0;
        int fuel = 0, ammo = 0;

        _reader.get_attack(i, ref s, ref h, ref a, ref n);
        _reader.get_defense(i, ref gd, ref ad, ref cd);
        _reader.get_fuel_ammo(i, ref fuel, ref ammo);

        return new UnitDto
        {
            Index = i,
            Name = _reader.get_unit_name(i)?.TrimEnd('\0') ?? string.Empty,
            Type = (UnitType)_reader.get_type(i),
            MoveType = (MoveType)_reader.get_move_type(i),
            SoftAttack = s,
            HardAttack = h,
            AirAttack = a,
            NavalAttack = n,
            GroundDefense = gd,
            AirDefense = ad,
            CloseDefense = cd,
            Initiative = _reader.get_initiative(i),
            Range = _reader.get_range(i),
            Spotting = _reader.get_spotting(i),
            Movement = _reader.get_movement(i),
            Fuel = fuel,
            Ammunition = ammo,
            Cost = _reader.get_cost(i),
            LevelPression = _reader.get_level_pression(i),
            InitForce = _reader.get_init_force(i),
            IsGroundUnit = _reader.get_ground_unit(i) == 0,
            Unknown1 = _reader.get_unknown1(i),
            Unknown4 = _reader.get_unknown4(i),
            Unknown5 = _reader.get_unknown5(i),
            LittleIcon = _reader.get_little_icon(i),
        };
    }

    public void WriteBack(UnitDto u)
    {
        if (!_initialised) throw new InvalidOperationException("尚未開啟檔案。");

        _reader.set_unit_name(u.Index, u.Name);
        _reader.set_attack(u.Index, u.SoftAttack, u.HardAttack, u.AirAttack, u.NavalAttack);
        _reader.set_defense(u.Index, u.GroundDefense, u.AirDefense, u.CloseDefense);
        _reader.set_initiative(u.Index, u.Initiative);
        _reader.set_range(u.Index, u.Range);
        _reader.set_spotting(u.Index, u.Spotting);
        _reader.set_movement(u.Index, u.Movement);
        _reader.set_fuel_ammo(u.Index, u.Fuel, u.Ammunition);
        _reader.set_cost(u.Index, u.Cost);
        _reader.set_level_pression(u.Index, u.LevelPression);
        _reader.set_init_force(u.Index, u.InitForce);

        _reader.write_back(u.Index);
    }
}
