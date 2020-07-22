using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace MyCompany.Models
{
    public class PaySlip
    {
        public Guid Id { get; set; }

        public string Organisation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string TabNumber { get; set; }

        public string Department { get; set; }

        public string Position { get; set; }

        public float Income { get; set; }

        public IEnumerable<Accrued> Accrued { get; set; }

        public IEnumerable<Accrued> IncomeKind { get; set; }

        public IEnumerable<Accrued> Deducted { get; set; }

        public IEnumerable<Accrued> PaidOut { get; set; }
    }

    public class Accrued
    {
        public string Type { get; set; }

        public DateTime Period { get; set; }

        public float WorkedOutDays { get; set; }

        public float WorkedOutHours { get; set; }

        public float PaidDays { get; set; }

        public float PaidHours { get; set; }

        public float Amount { get; set; }
    }

    public class AccruedGroup: ObservableCollection<Accrued>
    {
        public AccruedGroup(string name, List<Accrued> accrueds) :base(accrueds)
        {
            Name = name;
        }

        public string Name { get; set; }

        public float TotalAmount { get { return this.Sum(p => p.Amount); } }

        public float TotalWorkedOutDays { get { return this.Sum(p => p.WorkedOutDays); } }

        public float TotalWorkedOutHours { get { return this.Sum(p => p.WorkedOutHours); } }

        public float TotalPaidDays { get { return this.Sum(p => p.PaidDays); } }

        public float TotalPaidHours { get { return this.Sum(p => p.PaidHours); } }

    }
}
