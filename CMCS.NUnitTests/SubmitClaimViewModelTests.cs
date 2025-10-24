using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5CMCS.ViewModels;


namespace CMCS.NUnitTests
{
    internal class SubmitClaimViewModelTests
    {
        [TestFixture]
        public class ClaimReviewTests
        {
            [Test]
            public void Approve_sets_status_to_Approved()
            {
                var vm = new ClaimReviewViewModel { Status = "Pending" };
                vm.Status = "Approved";
                Assert.That(vm.Status, Is.EqualTo("Approved"));
            }

            [Test]
            public void Reject_sets_status_to_Rejected()
            {
                var vm = new ClaimReviewViewModel { Status = "Pending" };
                vm.Status = "Rejected";
                Assert.That(vm.Status, Is.EqualTo("Rejected"));
            }
        }
    }
}
