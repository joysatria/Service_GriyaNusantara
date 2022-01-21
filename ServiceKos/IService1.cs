using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceKos
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string pemesanan(string IDPemesanan, string NamaPemesan, string NoTelpon, int WaktuSewa, string IDKamar); //proses input data

        [OperationContract]
        string editPemesanan(string IDPemesanan, string NamaPemesan, string No_telpon);

        [OperationContract]
        string deletePemesanan(string IDPemesanan);

        [OperationContract]
        List<CekKos> ReviewKos();

        [OperationContract]
        List<DetailKos> DetailKos();

        [OperationContract]
        List<Pemesanan> Pemesanan();

        [OperationContract]
        string Login(string username, string password);

        [OperationContract]
        string Register(string username, string password, string kategori);

        [OperationContract]
        string UpdateRegister(string username, string password, string kategori, int id);

        [OperationContract]
        string DeleteRegister(string username);

        [OperationContract]
        List<DataRegister> DataRegist();
    }

    [DataContract]
    public class DataRegister
    {
        [DataMember(Order = 1)]
        public int id { get; set; }
        [DataMember(Order = 2)]
        public string username { get; set; }
        [DataMember(Order = 3)]
        public string password { get; set; }
        [DataMember(Order = 4)]
        public string kategori { get; set; }
    }

    [DataContract]
    public class Pemesanan
    {
        [DataMember]
        public string IDPemesanan { get; set; }

        [DataMember]
        public string NamaPemesan { get; set; }

        [DataMember]
        public string NoTelpon { get; set; }

        [DataMember]
        public int WaktuSewa { get; set; }

        [DataMember]
        public string IDKamar { get; set; }
    }

    [DataContract]
    public class DetailKos
    {
        [DataMember]
        public string IDKamar { get; set; }

        [DataMember]
        public string NamaKamar { get; set; }

        [DataMember]
        public string Deskripsi { get; set; }

        [DataMember]
        public string Harga { get; set; }

        [DataMember]
        public string Ketersediaan { get; set; }
    }

    [DataContract]
    public class CekKos
    {
        [DataMember]
        public string IDKamar { get; set; }

        [DataMember]
        public string NamaKamar { get; set; }

        [DataMember]
        public string Deskripsi { get; set; }
    }
}
