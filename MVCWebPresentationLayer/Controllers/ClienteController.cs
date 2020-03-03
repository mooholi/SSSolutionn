using AutoMapper;
using BLL.Impl;
using Common;
using DTO;
using MVCWebPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCWebPresentationLayer.Controllers
{
    public class ClienteController : Controller
    {
        //Os Métodos Http mais populares são GET e POST.
        //Por padrão, todo hiperlink ou url digitada manualmente, efetuará uma chamada
        //ao servidor utilizando o método GET.
        //O POST é utilizado quando queremos ENVIAR dados ao servidor, então é mais comum
        //termos ele em um form com vários componentes inputs
        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(ClienteInsertViewModel viewModel)
        {
            ClienteService svc = new ClienteService();

            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ClienteInsertViewModel, ClienteDTO>();
            });

            IMapper mapper = configuration.CreateMapper();
            // new SERService().GetSERByID(4);
            //Transforma o ClienteInsertViewModel em um ClienteDTO
            ClienteDTO dto = mapper.Map<ClienteDTO>(viewModel);
            try
            {
                svc.Insert(dto);
                //Se funcionou, redireciona pra página inicial
                return RedirectToAction("Home", "Index");
            }
            catch (NecoException ex)
            {
                //Se caiu aqui, o ClienteService lançou a exceção por validação de campos
                ViewBag.ValidationErrors = ex.Errors;
            }
            catch (Exception ex)
            {
                //Se caiu aqui, o ClienteService lançou uma exceção genérica, provavelmente por falha de acesso ao banco
                ViewBag.ErrorMessage = ex.Message;
            }
            //Se chegou aqui, temos erro
            return View();
        }

        //meusite.com/Cliente
        //meusite.com/Cliente/Index
        public async Task<ActionResult> Index()
        {
            try
            {
                ClienteService svc = new ClienteService();
                
                //Este objeto "clientes" é uma Lista de objetos DTO
                List<ClienteDTO> clientes = await svc.GetData();

                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<ClienteDTO, ClienteQueryViewModel>();
                });

                IMapper mapper = configuration.CreateMapper();
                // new SERService().GetSERByID(4);
                //Transforma o ClienteInsertViewModel em um ClienteDTO
               
                //Este objeto "dados" é uma lista de objetos ViewModel
                List<ClienteQueryViewModel> dados = mapper.Map<List<ClienteQueryViewModel>>(clientes);

                return View(dados);
            }
            catch (Exception)
            {

                return View();
            }
        }

    }
}