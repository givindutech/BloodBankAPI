using BloodBankAPI.Controllers;
using BloodBankAPI.InterfaceRepository;
using BloodBankAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace BloodTestProject;

[TestClass]
public class Test1
{
    
    [TestMethod]
    public void TestMethod1()
    {
        var expectedData = new List<BloodBank>
        {
            new BloodBank { BloodBankID = 1, BloodBankName= "City Blood Bank", Address = "123 Main Street, Downtown",City="Hyderabad",ContactNumber="555-1234",UserId="govind",Password="test123" },
            new BloodBank { BloodBankID = 1, BloodBankName= "Greenfield Blood Center", Address = "456 Oak Avenue",City="Bangalore",ContactNumber="555-5678",UserId="santosh",Password="jamestest" }
        };
        var mockUserDetails = new Mock<IUserDetails>();
        mockUserDetails.Setup(repo => repo.getBloodBankDetails()).Returns(expectedData);
        var controller = new UserDetailsController(mockUserDetails.Object);
        var result = controller.getBloodBankDetails();
        //assert
        var okResult = Assert.IsType<ActionResult<IEnumerable<BloodBank>>>(result);
        Assert.Equal(okResult, expectedData);

    }
}
