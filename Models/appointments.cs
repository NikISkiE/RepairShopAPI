namespace RepairShopAPI
{
    public class appointments
    {
    public int appointment_id { get; set; }
    public int client_id { get; set; }
    public int worker_id { get; set; }
    public DateTime appointment_startdate { get; set; }
    public DateTime appointment_starttime { get; set; }
    public DateTime appointment_aproximateddate { get; set; }
    public DateTime appointment_approximatedtime { get; set; }
    public DateTime appointment_enddate { get; set; }
    public string appointment_reason { get; set; }
    public string status { get; set; }
    }
}