using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class QueryExcel : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Query { get; set; } = null!;

    public string FilePath { get; set; } = null!;

    public bool IsOpenEditor { get; set; }

    public bool IsColumnHeaders { get; set; }

    public string Users { get; set; } = null!;

    public GenderType GenderType { get; set; }

    public string EmployeesParameter { get; set; } = null!;

    public string DateStartParameter { get; set; } = null!;

    public string DateEndParameter { get; set; } = null!;
}
