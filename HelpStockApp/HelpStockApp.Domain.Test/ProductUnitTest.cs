using FluentAssertions;
using HelpStockApp.Domain.Entities;
using HelpStockApp.Domain.Validation;
using Xunit;

namespace HelpStockApp.Domain.Test
{
    public class ProductUnitTest
    {
        #region Testes Positivos de Produto
        [Fact(DisplayName = "Create Product With Valid State")]
        public void CreateProduct_WithValidStateParameters_ResultObjectsValidState()
        {
            Action action = () => new Product(1, "Product Name", "Description", 10, 50, "Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Produto
        [Fact(DisplayName = "Create Product With Invalid Id")]
        public void CreateProduct_WithInvalidIdParameters_ResultException()
        {
            Action action = () => new Product(-1, "Invalid Id", "Description", 10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value.");
        }

        [Fact(DisplayName = "Create Product With Invalid Name")]
        public void CreateProduct_WithInvalidNameParameters_ResultException()
        {
            Action action = () => new Product(1, "ab", "Description", 10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too short. minimum 3 characters!");
        }

        [Fact(DisplayName = "Create Product With Long Image")]
        public void CreateProduct_WithLongImageParameters_ResultException()
        {
            Action action = () => new Product(1, "Long Image", "Description", 10, 50, "https://www.google.com/search?q=url+com++de+251+caracteres&sca_esv=60dc7b8df89f0db7&sca_upv=1&rlz=1C1GCEU_pt-BRBR1123BR1123&ei=dXPxZta5IvDc5OUP2Jem6Aw&ved=0ahUKEwiWyJKAnNmIAxVwLrkGHdiLCc0Q4dUDCA8&uact=5&oq=url+com++de+251+caracteres&gs_lp=Egxnd3Mtd2l6LXNlcnAiGnVybCBjb20gIGRlIDI1MSBjYXJhY3RlcmVzMggQIRigARjDBEi9D1CuA1jFDXADeAGQAQCYAbIBoAG_BqoBAzAuNrgBA8gBAPgBAZgCCKACoAXCAgoQABiwAxjWBBhHwgIIEAAYgAQYogTCAgQQIRgKmAMAiAYBkAYIkgcDMy41oAesDw&sclient=gws-wiz-serp");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image URL, too long. maximum 250 characters!");
        }

        [Fact(DisplayName = "Create Product With Null Image")]
        public void CreateProduct_WithNullImageParameters_ResultException()
        {
            Action action = () => new Product(1, "Null Image", "Description", 10, 50, null);
            action.Should().Throw<NullReferenceException>();
        }

        [Fact(DisplayName = "Create Product With Empty Image")]
        public void CreateProduct_WithEmptyImageParameters_ResultException()
        {
            Action action = () => new Product(1, "Empty Image", "Description", 10, 50, "");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid image, image is required!");
        }

        [Fact(DisplayName = "Create Product With Negative Stock")]
        public void CreateProduct_WithNegativeStockParameters_ResultException()
        {
            Action action = () => new Product(1, "Negative Stock", "Description", 10, -50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Stock, stock negative value is unlikely!");
        }

        [Fact(DisplayName = "Create Product With Negative Price")]
        public void CreateProduct_WithNegativePriceParameters_ResultException()
        {
            Action action = () => new Product(1, "Negative Price", "Description", -10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Price, price negative value is unlikely!");
        }

        // - 4 Adicionais

        [Fact(DisplayName = "Create Product With Empty Name")]
        public void CreateProduct_WithEmptyNameParameters_ResultException()
        {
            Action action = () => new Product(1, "", "Description", 10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, name is required!");
        }

        [Fact(DisplayName = "Create Product With Short Description")]
        public void CreateProduct_WithShortDescriptionParameters_ResultException()
        {
            Action action = () => new Product(1, "Description", "abcd", 10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, too short. minimum 5 characters!");
        }

        [Fact(DisplayName = "Create Product With Empty Description")]
        public void CreateProduct_WithEmptyDescriptionParameters_ResultException()
        {
            Action action = () => new Product(1, "Description", "", 10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid description, description is required!");
        }

        [Fact(DisplayName = "Create Product With Long Name")]
        public void CreateProduct_WithLongNameParameters_ResultException()
        {
            Action action = () => new Product(1, "Pedro de Alcântara João Carlos Leopoldo Salvador Bibiano Francisco Xavier de Paula Leocádio Miguel Gabriel Rafael Gonzaga", "Description", 10, 50, "Image");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name, too long. maximum 50 characters!");
        }

        #endregion
    }
}
