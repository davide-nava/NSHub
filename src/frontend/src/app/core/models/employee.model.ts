export interface Employee {
  ID: number;
  FirstName: string;
  LastName: string;
  Prefix?: string;
  Position: string;
  Picture: string;
  BirthDate: Date;
  HireDate: Date;
  Notes: string;
  Address: string;
}

export interface ScreenColCount {
  xs?: number;
  sm?: number;
  md?: number;
  lg?: number;
}

