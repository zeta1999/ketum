using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace Ketum.Entity

{
    [Table("MonitorStep")]
    public class KTDMonitorStep
    {
        [Key] public Guid MonitorStepId { get; set; }

        public Guid MonitorId { get; set; }
        public KTDMonitorStepTypes Type { get; set; }
        public string Settings { get; set; }
        public int Interval { get; set; }
        public KTDMonitorStepStatusTypes Status { get; set; }

        public DateTime LastCheckDate { get; set; } //Orderby etmek için.

        public KTDSMonitorStepSettingsRequest SettingsAsRequest()
        {
            return JsonConvert.DeserializeObject<KTDSMonitorStepSettingsRequest>(Settings);
        }
    }

    public enum KTDMonitorStepStatusTypes : short
    {
        Unknown = 0,
        Pending = 1,
        Processing = 2,
        Success = 3,
        Warning = 4,
        Fail = 5,
        Error = 6
    }

    public enum KTDMonitorStepTypes : short
    {
        Unknown = 0,
        Request = 1,
        StatusCode = 2,
        HeaderExists = 3,
        BodyContains = 4
    }

    public class KTDSMonitorStepSettingsRequest
    {
        public string Url { get; set; }
    }
}