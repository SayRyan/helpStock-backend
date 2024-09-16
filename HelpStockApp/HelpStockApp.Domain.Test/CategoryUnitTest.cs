using HelpStockApp.Domain.Entities;
using FluentAssertions;
using Xunit;
using HelpStockApp.Domain.Validation;

namespace HelpStockApp.Domain.Test
{
        #region Testes Positivos de Categoria
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParemeters_ResultObejectsValidState()
        {
            Action action= () => new Category(1, "Category name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        #endregion

        #region Testes Negativos de Categoria

        [Fact(DisplayName = "Create Category With Invalid Id")]
        public void CreateCategory_WithInvalidParemeters_ResultException()
        {
            Action action = () => new Category(-1, "Eletronics");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid Id Value.");
        }
        /*
            Create Category With Name Too Short Parameter
            Create Category With Name Null Parameter
            Create Category With Name Missing Parameter
            Create Category With Name Invalid Id Caracter Id
            Create Category With Name Parameter Name Alone
         */
        #endregion
    }
}
