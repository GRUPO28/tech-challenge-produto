using ControlePedidos.Common.Exceptions;
using ControlePedidos.Produto.Domain.Enums;

namespace ControlePedidos.BDD.StepDefinitions
{
    [Binding]
    public class ProdutoSteps
    {
        private string _id;
        private string _name;
        private List<KeyValuePair<string, decimal>> _sizePrice;
        private TipoProduto _productType;
        private string _description;
        private DateTime _creationDate;
        private bool _active;
        private Produto.Domain.Entities.Produto _product;
        private Exception _exception;

        [Given(@"the product has valid data")]
        public void GivenTheProductHasValidData()
        {
            _id = "1";
            _name = "Product 1";
            _sizePrice = new List<KeyValuePair<string, decimal>>()
            {
                new KeyValuePair<string, decimal>("S", 10),
                new KeyValuePair<string, decimal>("M", 15),
                new KeyValuePair<string, decimal>("L", 20)
            };
            _productType = TipoProduto.Acompanhamento;
            _description = "Description of Product 1";
            _creationDate = DateTime.UtcNow;
            _active = true;
        }

        [Given(@"the product has no name")]
        public void GivenTheProductHasNoName()
        {
            GivenTheProductHasValidData();
            _name = null;
        }

        [Given(@"the product has no size and price")]
        public void GivenTheProductHasNoSizeAndPrice()
        {
            GivenTheProductHasValidData();
            _sizePrice = null;
        }

        [Given(@"the product has no description")]
        public void GivenTheProductHasNoDescription()
        {
            GivenTheProductHasValidData();
            _description = null;
        }

        [When(@"I create the product")]
        public void WhenICreateTheProduct()
        {
            _product = new Produto.Domain.Entities.Produto(_id, _name, _sizePrice, _productType, _description, _creationDate, _active);
        }

        [When(@"I try to create the product")]
        public void WhenITryToCreateTheProduct()
        {
            try
            {
                _product = new Produto.Domain.Entities.Produto(_id, _name, _sizePrice, _productType, _description, _creationDate, _active);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"the product should be created successfully")]
        public void ThenTheProductShouldBeCreatedSuccessfully()
        {
            Assert.NotNull(_product);
        }

        [Then(@"a domain notification exception should be thrown")]
        public void ThenADomainNotificationExceptionShouldBeThrown()
        {
            Assert.NotNull(_exception);
            Assert.IsType<DomainNotificationException>(_exception);
        }
    }
}