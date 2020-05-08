﻿using CardknoxApi.Operations;
using System;
using System.Collections.Generic;
using System.Text;

namespace CardknoxApi.RecurringOperations
{
    /// <summary>
    /// Use this command to add a new customer record, which can then be linked to future payment methods and schedules. Creating a new schedule without linking it to an existing customer automatically generates a new customer for you.
    /// </summary>
    public class CustomerAdd : Customer
    {
        internal string Operation => "customer:add";

        /// <summary>
        /// 
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CardknoxCustomFields CustomFields { get; set; } = new CardknoxCustomFields();
    }

    /// <summary>
    /// <para>Use this command to update existing customer information.</para>
    /// <para>Note: All fields with values must be passed in (even fields that are not being updated). Any fields not passed in are treated as being set to blank.</para>
    /// </summary>
    public class CustomerUpdate : Customer
    {
        internal string Operation => "customer:update";

        /// <summary>
        /// Customer's Unique ID number. This field cannot be updated.
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// Indeicates the default payment method used to process the transaction
        /// </summary>
        public string DefaultPaymentMethodID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string CustomerNotes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public CardknoxCustomFields CustomFields { get; set; } = new CardknoxCustomFields();
    }

    /// <summary>
    /// <para>Use this command to remove a customer record.</para>
    /// <para>Note: The customer record is not completely deleted from the database; instead, the removed property is set to true. Customers with active schedules cannot be removed.</para>
    /// </summary>
    public class CustomerRemove
    {
        internal string Operation => "customer:remove";

        /// <summary>
        /// Customer's Unique ID number. This field cannot be updated.
        /// </summary>
        public string CustomerID { get; set; }
    }

    /// <summary>
    /// Use this command to retrieve a customer's details.
    /// </summary>
    public class CustomerGet
    {
        internal string Operation => "report:customer";

        /// <summary>
        /// Customer's Unique ID number. This field cannot be updated.
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// Indicates whether to return deleted rows
        /// </summary>
        public bool Removed { get; set; }
    }

    /// <summary>
    /// Use this command to find customers using specific search parameters.
    /// </summary>
    public class CustomerFind : Customer
    {
        internal string Operation => "report:customers";

        /// <summary>
        /// Customer's Unique ID number. This field cannot be updated.
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// Indicates whether to return deleted rows
        /// </summary>
        public bool Removed { get; set; }
    }

    /// <summary>
    /// <para>Use this command to process a single transaction from the API using either the xPaymentMethodID parameter or just the xCustomerID parameter (in which case the customer's default payment method is used).</para>
    /// <para>You can pass in the xUseBackupPaymentMethods parameter to specify trying other payment methods belonging to the customer if the transaction is declined.</para>
    /// </summary>
    public class CustomerTransaction : OperationBase
    {
        internal string Operation => "customer:transaction";

        /// <summary>
        /// Customer's Unique ID number. This field cannot be updated.
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// Payment method's unique ID. Required if xCustomerID is not passed in.
        /// </summary>
        public string PaymentMethodID { get; set; }

        /// <summary>
        /// <para>Indicates whether to use the customer's other payment methods for the charge if the transaction is declined</para>
        /// <para>Note: This is not allowed if using a new payment method that has not been saved.</para>
        /// </summary>
        public bool UseBackupPaymentMethods { get; set; }
    }
}