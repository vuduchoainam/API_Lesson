namespace Lessonapi.Data
{
    public enum TinhTrangDonDatHang
    {
        New = 0,
        Payment = 1,
        Complete = 2,
        Cancel = -1
    }
    public class Order
    {
        public Guid OrderId { get; set; }
        public DateTime NgayDH { get; set; }
        public DateTime? NgayGiao { get; set; }
        public TinhTrangDonDatHang TinhTrangDonHang { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }


        public ICollection<OrderDetail> OrderDetails { get; set; }
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
    }
}
