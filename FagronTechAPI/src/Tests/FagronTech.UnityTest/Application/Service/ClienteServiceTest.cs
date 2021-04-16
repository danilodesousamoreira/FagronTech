
using AutoFixture;

using AutoMapper;

using FagronTech.Application.Services;
using FagronTech.Application.ViewModels;
using FagronTech.Domain.Business.Interfaces;
using FagronTech.Domain.Entities;
using FagronTech.Infrastructure.Common;

using FluentValidation.Results;

using Moq;

using System;

using Xunit;

namespace FagronTech.UnityTest.Service.Application
{

    public class ClienteServiceTest : BaseTestService
    {
        private readonly Cliente _entity;
        private readonly ClienteInsertViewModel _insertViewModel;
        private readonly ClienteUpdateViewModel _updateViewModel;

        private readonly Mock<IMapper> _mockMapper;
        private readonly Mock<IClienteBusiness> _mockBusiness;
        private readonly Mock<INotification> _mockNotification;
        
        private readonly ClienteService _service;
        private readonly Exception _exception;

        public ClienteServiceTest()
        {
            _entity = _fixture.Build<Cliente>().Create();
            _insertViewModel = _fixture.Create<ClienteInsertViewModel>();
            _updateViewModel = _fixture.Create<ClienteUpdateViewModel>();

            _mockBusiness = new Mock<IClienteBusiness>();

            _exception = _fixture.Create<Exception>();

            

            _mockMapper = new Mock<IMapper>();
            _mockNotification = new Mock<INotification>();

            _service = new ClienteService(_mockBusiness.Object, _mockMapper.Object);
        }


        #region Inserir()

        [Fact]
        public void Inserir_sucesso()
        {
            //arrange
            _mockMapper.Setup(m => m.Map<Cliente>(_insertViewModel)).Returns(_entity);

            //action
            _service.Inserir(_insertViewModel);

            //assert
            _mockBusiness.Verify(b => b.Insert(_entity), Times.Once);
            _mockMapper.Verify(m => m.Map<Cliente>(_insertViewModel), Times.Once);
        }

        [Fact]
        public void Inserir_autoMapper_falha_throw_exception()
        {
            //arrange
            _mockMapper.Setup(m => m.Map<Cliente>(_insertViewModel)).Throws(_exception);

            //assert
            Assert.Throws<Exception>(() => _service.Inserir(_insertViewModel));
            _mockBusiness.Verify(b => b.Insert(It.IsAny<Cliente>()), Times.Never);
            _mockMapper.Verify(m => m.Map<Cliente>(_insertViewModel), Times.Once);
        }

        [Fact]
        public void Inserir_business_falha_throw_exception()
        {
            //arrange
            _mockMapper.Setup(m => m.Map<Cliente>(_insertViewModel)).Returns(_entity);
            _mockBusiness.Setup(b => b.Insert(It.IsAny<Cliente>())).Throws(_exception);

            //assert
            Assert.Throws<Exception>(() => _service.Inserir(_insertViewModel));
            _mockBusiness.Verify(b => b.Insert(_entity), Times.Once);
            _mockMapper.Verify(m => m.Map<Cliente>(_insertViewModel), Times.Once);
        }

        #endregion

        #region Atualizar()

        [Fact]
        public void Update_sucesso()
        {
            //arrange 
            int id = 1;
            _mockBusiness.Setup(b => b.GetById(id)).Returns(_entity);
            _mockMapper.Setup(m => m.Map(_updateViewModel, _entity)).Returns(_entity);

            //action
            _service.Atualizar(id, _updateViewModel);

            //assert
            _mockBusiness.Verify(b => b.GetById(id), Times.Once);
            _mockMapper.Verify(m => m.Map(_updateViewModel, _entity), Times.Once);
            _mockBusiness.Verify(b => b.Update(_entity), Times.Once);
        }

        [Fact]
        public void Update_autoMapper_throw_exception()
        {
            //arrange
            int id = 1;
            _mockBusiness.Setup(b => b.GetById(id)).Returns(_entity);
            _mockMapper.Setup(m => m.Map(_updateViewModel, _entity)).Throws(_exception);

            //assert
            Assert.Throws<Exception>(() => _service.Atualizar(id, _updateViewModel));
            _mockBusiness.Verify(b => b.GetById(id), Times.Once);
            _mockMapper.Verify(m => m.Map(_updateViewModel, _entity), Times.Once);
            _mockBusiness.Verify(b => b.Update(_entity), Times.Never);
        }

        [Fact]
        public void Update_business_update_throw_exception()
        {
            //arrange
            int id = 1;
            _mockBusiness.Setup(b => b.GetById(id)).Returns(_entity);
            _mockBusiness.Setup(b => b.Update(_entity)).Throws(_exception);
            _mockMapper.Setup(m => m.Map(_updateViewModel, _entity)).Returns(_entity);

            //assert
            Assert.Throws<Exception>(() => _service.Atualizar(id, _updateViewModel));
            _mockBusiness.Verify(b => b.GetById(id), Times.Once);
            _mockMapper.Verify(m => m.Map(_updateViewModel, _entity), Times.Once);
            _mockBusiness.Verify(b => b.Update(_entity), Times.Once);
        }

        [Fact]
        public void Update_business_getById_throw_exception()
        {
            //arrange
            int id = 1;
            _mockBusiness.Setup(b => b.GetById(id)).Throws(_exception);

            //assert
            Assert.Throws<Exception>(() => _service.Atualizar(id, _updateViewModel));
            _mockBusiness.Verify(b => b.GetById(id), Times.Once);
            _mockMapper.Verify(m => m.Map(_updateViewModel, _entity), Times.Never);
            _mockBusiness.Verify(b => b.Update(_entity), Times.Never);
        }

        [Fact]
        public void Update_business_getById_return_null()
        {
            //arrange
            int id = 1;
            _mockBusiness.Setup(b => b.GetById(id)).Returns(default(Cliente));

            //action
            _service.Atualizar(id, _updateViewModel);

            //assert
            //_mockNotification.Verify(n => n.AddFailure(It.IsAny<ValidationFailure>()), Times.Once);
            _mockBusiness.Verify(b => b.GetById(id), Times.Once);
            _mockMapper.Verify(m => m.Map(_updateViewModel, _entity), Times.Never);
            _mockBusiness.Verify(b => b.Update(_entity), Times.Never);
        }

        #endregion
    }
}