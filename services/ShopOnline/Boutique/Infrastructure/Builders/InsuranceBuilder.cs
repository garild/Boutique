﻿using System;
using System.Collections.Generic;
using System.IO;
using Boutique.Domain.Insurances;
using Boutique.Domain.Insurances.Enum;
using Boutique.Domain.Insurances.Insureds;

namespace Boutique.Infrastructure.Builders
{
    public class InsureBuilder
    {
        private static DateTime StartInsurance { get; set; }
        private static DateTime EndInsurance { get; set; }
        private static List<Insured> Insureds { get; set; }
        private static InsuranceStatusEnum Status { get; set; }

        public InsureBuilder SetStartInsurance(DateTime time)
        {
            StartInsurance = time;
            return this;
        }

        public InsureBuilder SetEndInsurance(DateTime time)
        {
            EndInsurance = time;
            return this;
        }

        public  InsureBuilder SetInsureds(List<Insured> insureds)
        {
            Insureds = insureds;
           return this;
        }

        public InsureBuilder SetStatus()
        {
            Status = InsuranceStatusEnum.Registered;
            return this;
        }

        public Insurance Build()
        {
            return new Insurance(Guid.NewGuid().ToString("N"), DateTime.Now, StartInsurance, EndInsurance, Insureds, Status);
        }
    }
}