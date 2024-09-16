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

        [Fact(DisplayName = "Create Category With Name Parameter Name Alone")]
        public void CreateCategory_WithNameParemetersNameAlone_ResultException()
        {
            Action action = () => new Category("Alone");
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

        [Fact(DisplayName = "Create Category With Name Too Short Parameter")]
        public void CreateCategory_WithNameTooShortParemeters_ResultException()
        {
            Action action = () => new Category(1, "AB");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, too short. Minimum 3 characters!");   
        }

        [Fact(DisplayName = "Create Category With Name Null Parameter")]
        public void CreateCategory_WithNameNullParemeters_ResultException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        /*
            Create Category With Name Invalid Id Caracter Id
            Create Category With Name Parameter Name Alone
         */

        [Fact(DisplayName = "Create Category With Name Missing Parameter")]
        public void CreateCategory_WithNameMissingParemeters_ResultException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Invalid name, name is required!");
        }

        #endregion
    }
}
