using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;

namespace DataMSA
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MSAService1
    {
        
        // To use HTTP GET, add [WebGet] attribute. (Default ResponseFormat is WebMessageFormat.Json)
        // To create an operation that returns XML,
        //     add [WebGet(ResponseFormat=WebMessageFormat.Xml)],
        //     and include the following line in the operation body:
        //         WebOperationContext.Current.OutgoingResponse.ContentType = "text/xml";
        [OperationContract]
        [WebGet]
        public Entreprise InfoEntreprise()
        {
            var db = new MSAEntities();
            var Entreprise = (from e in db.Entreprises
                              select e).SingleOrDefault();
            return Entreprise;
        }


        [OperationContract]
        [WebGet]
        public List<InfosChambres>roomsoccupy()
        {
            var db = new MSAEntities();
            var ChambresOccuper = (from c in db.Chambres
                                   join ce in db.Chambres_Emplacement
                                   on c.Emplacement_ID equals ce.Emplacement_ID
                                   join ins in db.Inscriptions
                                   on c.Chambre_ID equals ins.Chambre_ID
                                   join bnf in db.Beneficiaires
                                   on ins.Bnf_ID equals bnf.Bnf_ID
                                   join Ref in db.Source_Ref
                                   on ins.Ref_ID equals Ref.Ref_ID
                                   select new InfosChambres()
                                   
                                   
                                   {
                                       ChambreID = c.Chambre_ID,
                                       ChambreName = c.Chambre_Numero,
                                       ChambreEmplacement = ce.Emplacement_Name,
                                       ChambreAdresse = ce.Emplacemetn_Adresse,
                                       ChambreUserId = bnf.Bnf_ID,
                                       ChambreUserFirstName = bnf.Bnf_Nom,
                                       ChambreUserLastName = bnf.Bnf_Prenom,
                                       ChambreBegin = ins.Ins_DateDebut,
                                       ChambreFin = ins.Ins_DateFin,
                                       ChambreAdmin = Ref.Ref_Name
                                   }).ToList();
                                
            return (ChambresOccuper);
        }


        [OperationContract]
        [WebGet]
        public List<GetRooms> GetAllRooms()
        {
            var db = new MSAEntities();
            var AllRooms = (from c in db.Chambres
                            join ce in db.Chambres_Emplacement
                            on c.Emplacement_ID equals ce.Emplacement_ID                                                       
                            select new GetRooms()
                            {
                            ChambreID = c.Chambre_ID,
                            ChambreName = c.Chambre_Numero,
                            ChambreEmplacement = ce.Emplacement_Name,
                            ChambreAdresse = ce.Emplacemetn_Adresse                           
                        }).ToList();

            return (AllRooms);
        }

        [OperationContract]
        [WebGet]
        public List<Beneficiaire> GetUsers()
        {
            var db = new MSAEntities();
            var Users = (from b in db.Beneficiaires
                         select new beneficiairedisplay()
                         {
                            beniLastName = b.Bnf_Nom,
                            beniFirstName = b.Bnf_Prenom,
                            beniDateNais = b.Bnf_DateNais,
                            beniID = b.Bnf_ID,
                            beni
                         }).ToList();
            return Users;
        }


        // Add more operations here and mark them with [OperationContract]
    }

    public class GetRooms
    {
        public GetRooms()
        {
        }

        public string ChambreAdresse { get; set; }
        public string ChambreEmplacement { get; set; }
        public int ChambreID { get; set; }
        public string ChambreName { get; set; }
    }

    public class InfosChambres
    {
        public InfosChambres()
        {
        }

        public string ChambreAdmin { get; set; }
        public string ChambreAdresse { get; set; }
        public DateTime ChambreBegin { get; set; }
        public string ChambreEmplacement { get; set; }
        public DateTime? ChambreFin { get; set; }
        public int ChambreID { get; set; }
        public string ChambreName { get; set; }
        public string ChambreUserFirstName { get; set; }
        public int ChambreUserId { get; set; }
        public string ChambreUserLastName { get; set; }
    }
}
