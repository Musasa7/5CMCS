using NUnit.Framework;
using ClaimReviewVM = global::_5CMCS.ViewModels.ClaimReviewViewModel;

namespace CMCS.NUnitTests
{
    [TestFixture]
    public class ClaimReviewModelTests
    {
        [Test]
        public void Approve_sets_status_to_Approved()
        {
            var vm = new ClaimReviewVM { Status = "Pending" };
            vm.Status = "Approved";
            Assert.That(vm.Status, Is.EqualTo("Approved"));
        }

        [Test]
        public void Reject_sets_status_to_Rejected()
        {
            var vm = new ClaimReviewVM { Status = "Pending" };
            vm.Status = "Rejected";
            Assert.That(vm.Status, Is.EqualTo("Rejected"));
        }
    }
}