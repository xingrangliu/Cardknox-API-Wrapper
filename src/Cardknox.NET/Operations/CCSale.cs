﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CardknoxApi.Operations
{
    /// <summary>
    /// 
    /// </summary>
    public class CCSale : OperationBase
    {
        public string Operation => CardknoxOperations.CCSale;

        public bool AllowPartialAuth { get; set; } = false;
        public decimal RxAmount { get; set; } = 0;
        public decimal DentalAmount { get; set; } = 0;
        public decimal VisionAmount { get; set; } = 0;
        public decimal TransitAmount { get; set; } = 0;
        public decimal CopayAmount { get; set; } = 0;
        public decimal ClinicalAmount { get; set; } = 0;

        public string OrderID { get; set; }
        public bool ExistingCustomer { get; set; } = false;
        public bool AllowDuplicate { get; set; } = false;
    }
}