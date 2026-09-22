using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class HolidayTableGroup : BaseEntityType
{


    public string ConsoleCols { get; set; } = null!;

    public string PrintAndWebCols { get; set; } = null!;

    public EquipmentSendModeType EquipmentSendModeType { get; set; }



}
