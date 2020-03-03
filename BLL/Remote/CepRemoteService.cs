using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
namespace NcMaster
{
    public class CepRemoteService
    {

        public string UF
        {
            get;
            private set;
        }
        public string Cidade
        {
            get;
            private set;
        }
        public string Bairro
        {
            get;
            private set;
        }
        public string TipoLogradouro
        {
            get;
            private set;
        }
        public string Logradouro
        {
            get;
            private set;
        }
        public string Resultado
        {
            get;
            private set;
        }
        public string ResultadoTXT
        {
            get;
            private set;
        }


        public CepRemoteService(string CEP)
        {
            UF = "";
            Cidade = "";
            Bairro = "";
            Logradouro = "";
            Resultado = "0";
            ResultadoTXT = "CEP não encontrado";

            //Cria um DataSet  baseado no retorno do XML  
            DataSet ds = new DataSet();
            ds.ReadXml("http://cep.republicavirtual.com.br/web_cep.php?cep=" + CEP.Replace("-", "").Trim() + "&formato=xml");

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    Resultado = ds.Tables[0].Rows[0]["resultado"].ToString();
                    switch (Resultado)
                    {
                        case "1":
                            UF = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                            Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                            Bairro = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                            TipoLogradouro = ds.Tables[0].Rows[0]["tipo_logradouro"].ToString().Trim();
                            Logradouro = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                            ResultadoTXT = "CEP completo";
                            break;
                        case "2":
                            UF = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
                            Cidade = ds.Tables[0].Rows[0]["cidade"].ToString().Trim();
                            Bairro = "";
                            TipoLogradouro = "";
                            Logradouro = "";
                            ResultadoTXT = "CEP  único";
                            break;
                        default:
                            UF = "";
                            Cidade = "";
                            Bairro = "";
                            TipoLogradouro = "";
                            Logradouro = "";
                            ResultadoTXT = "CEP não  encontrado";
                            break;
                    }
                }
            }
            //Exemplo do retorno da  WEB  
            //<?xml version="1.0"  encoding="iso-8859-1"?>  
            //<webservicecep>  
            //<uf>RS</uf>  
            //<cidade>Porto  Alegre</cidade>  
            //<bairro>Passo  D'Areia</bairro>  
            //<tipo_logradouro>Avenida</tipo_logradouro>  
            //<logradouro>Assis Brasil</logradouro>  
            //<resultado>1</resultado>  
            //<resultado_txt>sucesso - cep  completo</resultado_txt>  
            //</webservicecep>  
        }
    }
}