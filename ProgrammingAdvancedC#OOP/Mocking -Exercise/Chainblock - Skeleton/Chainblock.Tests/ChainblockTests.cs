using Chainblock.Contracts;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock.Tests
{
    [TestFixture]
    public class ChainblockTests
    {
        private IChainblock chainblock;

        [SetUp]
        public void Setup()
        {
            this.chainblock = new Chainblock();
        }

        [Test]
        public void Add_ThrowsException_WhenTransactionWithIdAlreadyExist()
        {
            int id = 1;
            this.chainblock.Add(new Transaction
            {
                Id = id,
                Amount = 100,
                From = "Kiko",
                To = "Mirko"
            });

            Assert.Throws<InvalidOperationException>(() => this.chainblock.Add(new Transaction
            {
                Id = id,
                From = "Mirko",
                To = "Kiko",
                Amount = 150
            }));
        }
        [Test]
        public void Add_ShouldAddsTransactionToChainblock()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Count, Is.EqualTo(1));
            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsTrue_WhenTransactionWithIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);

            Assert.That(this.chainblock.Contains(transaction.Id), Is.True);
        }

        [Test]
        public void ContainsId_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(this.chainblock.Contains(1), Is.False);
        }
        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionWithIdDoesNotExist()
        {
            Assert.That(this.chainblock.Contains(this.CreateSimpleTransaction()), Is.False);
        }
        [Test]
        public void ContainsTransaction_ReturnsFalse_WhenTransactionIdExistButOtherPropertisDoNotMatch()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);

            ITransaction searchingTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount + 50,
                From = transaction.From + "Fake",
                To = transaction.To + "Fake",
                Status = TransactionStatus.Failed

            };
            Assert.That(this.chainblock.Contains(searchingTransaction), Is.False);
        }
        [Test]
        public void Contains_ReturnsTrue_WhenTransactionMatchesChainblockTransaction()
        {
            ITransaction transaction = this.CreateSimpleTransaction();

            this.chainblock.Add(transaction);
            ITransaction searchingTransaction = new Transaction
            {
                Id = transaction.Id,
                Amount = transaction.Amount,
                From = transaction.From,
                To = transaction.To,
                Status = transaction.Status
            };

            Assert.That(this.chainblock.Contains(searchingTransaction), Is.True);
        }
        [Test]
        public void Count_ReturnsZero_WhenChainblockIsEmpty()
        {
            Assert.That(this.chainblock.Count, Is.Zero);
        }
        [Test]
        public void ChangeTransactionStatus_ThrowsExepticon_WhenIdDoesNotExist()
        {
            this.chainblock.Add(this.CreateSimpleTransaction());

            Assert.Throws<ArgumentException>(() => this.chainblock.ChangeTransactionStatus(100, TransactionStatus.Failed));
        }
        [Test]
        public void ChangeTransactionStatus_ChangesTransactionStatus_WhendIdExists()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);
            TransactionStatus newStatus = TransactionStatus.Unauthorized;
            this.chainblock.ChangeTransactionStatus(transaction.Id, TransactionStatus.Unauthorized);
            Assert.That(transaction.Status, Is.EqualTo(newStatus));
        }

        [Test]
        public void RemoveTransactionById_ThrowsExetion_WhenIdDoesNotExist()
        {
            this.chainblock.Add(this.CreateSimpleTransaction());

            Assert.Throws<InvalidOperationException>(() => this.chainblock.RemoveTransactionById(5));
        }
        [Test]
        public void RemoveTransaction_ChainblockTransaction_WhenIdExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);
            this.chainblock.RemoveTransactionById(transaction.Id);
            Assert.That(this.chainblock.Count, Is.Zero);
            Assert.That(this.chainblock.Contains(transaction.Id), Is.False);
        }
        [Test]
        public void GetById_ThrowsExeption_WhenOdDoesNotExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetById(transaction.Id + 1));
        }
        [Test]
        public void GetById_ReturnsExpectedTransaction_WhenIdtExist()
        {
            ITransaction transaction = this.CreateSimpleTransaction();
            this.chainblock.Add(transaction);
            ITransaction chainBlockTransaction = this.chainblock.GetById(transaction.Id);
            Assert.That(transaction, Is.EqualTo(chainBlockTransaction));
        }
        [Test]
        public void GetByTransactionStatus_ThrowsExeption_WhenThereAreNoTransactionWithNoStatus()
        {
            this.AddThreeTransactionWithDiferentStatus();
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByTransactionStatus(TransactionStatus.Unauthorized));
        }
        [Test]
        public void GetByTransactionStatus_ReturnsFiltredAndSortedData_WhenChainblockContainsTransactionsWithStatus()
        {
            this.AddBulkOfTransaction();
            TransactionStatus filterStatus = TransactionStatus.Successfull;
            List<ITransaction> expected = this.chainblock.Where(t => t.Status == TransactionStatus.Successfull).OrderByDescending(t => t.Amount).ToList();

            List<ITransaction> actual = this.chainblock.GetByTransactionStatus(filterStatus).ToList();

            Assert.That(expected, Is.EqualTo(actual));

        }



        [Test]
        public void GetAllSendersWithTransactionStatus_ThrowsExeption_WhenTransactionDoNotExistWithStatus()
        {
            this.AddThreeTransactionWithDiferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllSendersWithTransactionStatus(TransactionStatus.Unauthorized));
        }
        [Test]
        public void GetAllSendersWithTansactionStatus_ReturnFitredAndSortedData_WhenTransactionExist()
        {

            this.AddBulkOfTransaction();
            TransactionStatus status = TransactionStatus.Successfull;
            List<string> expected = this.chainblock.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.From).ToList();

            List<string> actual = this.chainblock.GetAllSendersWithTransactionStatus(status).ToList();
            Assert.That(expected, Is.EquivalentTo(actual));
        }
        [Test]
        public void GetAllReceiversWithTransactionStatus_ThrowsExceptionWhenStatusDoNotExit()
        {
            this.AddThreeTransactionWithDiferentStatus();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetAllReceiversWithTransactionStatus(TransactionStatus.Unauthorized));

        }
        [Test]
        public void GetllReceiversWithTransactionStatus_ReturnFiltredAndSortedData_WhenTransactionExist()
        {

            this.AddBulkOfTransaction();
            TransactionStatus status = TransactionStatus.Successfull;
            List<string> expected = this.chainblock.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.To).ToList();

            List<string> actual = this.chainblock.GetAllReceiversWithTransactionStatus(status).ToList();
            Assert.That(expected, Is.EquivalentTo(actual));
        }
        [Test]
        public void GetAllOrderedByAmountDescendingThenById_ReturnsTransactionInExpetedOrder()
        {
            this.AddBulkOfTransaction();

            List<ITransaction> expected = this.chainblock.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            List<ITransaction> actual = this.chainblock.GetAllOrderedByAmountDescendingThenById().ToList();
            Assert.That(expected, Is.EqualTo(actual));
        }
        [Test]
        public void GetBySenderOrderedByAmountDescending_ThrowsExceptionWhenSenderDoesNotExist()
        {
            this.AddBulkOfTransaction();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderOrderedByAmountDescending("Fakesender"));
        }
        [Test]
        public void GetBySenderOrderedByAmountDescending_ReturnsFiltredAndSortedData()
        {
            this.AddBulkOfTransaction();


            string sender = this.chainblock.FirstOrDefault().From;

            List<ITransaction> expected = this.chainblock.Where(t => t.From == sender).OrderByDescending(t => t.Amount).ToList();
            List<ITransaction> actual = this.chainblock.GetBySenderOrderedByAmountDescending(sender).ToList();

            Assert.That(expected, Is.EquivalentTo(actual));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenById_ThrowsExeption_WhenReceiverDoesNotExist()
        {
            this.AddBulkOfTransaction();

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetByReceiverOrderedByAmountThenById("Fakesender"));
        }
        [Test]
        public void GetByReceiverOrderedByAmountThenById_ReturnsFiltrerdAndSortedData()
        {
            this.AddBulkOfTransaction();


            string receiver = this.chainblock.FirstOrDefault().To;

            List<ITransaction> result = this.chainblock.GetByReceiverOrderedByAmountThenById(receiver).ToList();
            int id = 0;
            double prewAmount = double.PositiveInfinity;
            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.To, Is.EqualTo(receiver));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prewAmount));


                if (transaction.Amount == prewAmount)
                {
                    Assert.That(transaction.Id, Is.GreaterThan(id));
                }
                prewAmount = transaction.Amount;
                id = transaction.Id;
            }


        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnEmptyCollection_WhenTransactionStatusIsNotValid()
        {
            this.AddThreeTransactionWithDiferentStatus();


            Assert.That(this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Unauthorized, 100), Is.EquivalentTo(new List<ITransaction>()));
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnEmptyCollection_WhenAmountIsNotValid()
        {
            this.AddBulkOfTransaction();

            double amount = this.chainblock.FirstOrDefault().Amount / 2;
            List<ITransaction> actual = this.chainblock.GetByTransactionStatusAndMaximumAmount(TransactionStatus.Successfull, amount).ToList();
            Assert.That(actual, Is.EquivalentTo(new List<ITransaction>()));
        }
        [Test]
        public void GetByTransactionStatusAndMaximumAmount_ReturnFiltredAndSortedCollection()
        {
            this.AddBulkOfTransaction();
            TransactionStatus status = TransactionStatus.Successfull;
            double maxAmount = this.chainblock.Average(t => t.Amount);

            List<ITransaction> transactions = this.chainblock.GetByTransactionStatusAndMaximumAmount(status,maxAmount).ToList();

            double prewAmont = double.PositiveInfinity;

            foreach (ITransaction transaction in transactions)
            {
                Assert.That(transaction.Status, Is.EqualTo(status));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(maxAmount));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prewAmont));

                prewAmont = transaction.Amount;
            }

        }
        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsExeption_WhenSenderDoesNotExist()
        {
            this.AddBulkOfTransaction();
            double minAMount = this.chainblock.Min(t => t.Amount);
            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending("InvalidSender", minAMount));
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescending_ThrowsExeption_WhenTransactionWithAmountGreaterThanGivenDoesNotExist()
        {
            this.AddBulkOfTransaction();
            string sender = this.chainblock.FirstOrDefault().From;
            double minAMount = this.chainblock.Max(t => t.Amount) + 1;

            Assert.Throws<InvalidOperationException>(() => this.chainblock.GetBySenderAndMinimumAmountDescending(sender, minAMount));
        }
        [Test]
        public void GetBySenderAndMinimumAmountDescending_ReturnFiltredAndSortedData()
        {
            this.AddBulkOfTransaction();
            string sender = this.chainblock.FirstOrDefault().From;
            double minAMount = this.chainblock.Min(t => t.Amount);

            List<ITransaction> result = this.chainblock.GetBySenderAndMinimumAmountDescending(sender, minAMount).ToList();
            double prevAmount = double.PositiveInfinity;
            foreach (ITransaction transaction in result)
            {
                Assert.That(transaction.From, Is.EqualTo(sender));
                Assert.That(transaction.Amount, Is.GreaterThan(minAMount));
                Assert.That(transaction.Amount, Is.LessThanOrEqualTo(prevAmount));

                prevAmount = transaction.Amount;
            }
        }
        [Test]
        public void GetByReceiverAndAmountRangeShouldReturnCollectionOfGivenReciversWithThathAmountRange()
        {
            this.AddBulkOfTransaction();
            string receiver = this.chainblock.FirstOrDefault().To;
            double minAMount = this.chainblock.Min(t => t.Amount);
            double prevAmount = this.chainblock.Max(t => t.Amount);
            List<ITransaction> expected = this.chainblock.Where(t => t.From == receiver && t.Amount >= minAMount && t.Amount <= prevAmount).OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
            List<ITransaction> actual = this.chainblock.GetByReceiverAndAmountRange(receiver, minAMount, prevAmount).ToList();

            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEqual(expected, actual);
        }

        [Test]
        public void GetByReceiverAndAmountRangeShouldThrowInvalidOperationExeption()
        {
            this.AddBulkOfTransaction();
            double minAMount = this.chainblock.Min(t => t.Amount);
            double prevAmount = double.PositiveInfinity;

            Assert.Throws<InvalidOperationException>(() =>
            {
                this.chainblock.GetByReceiverAndAmountRange("Anzhela", minAMount, prevAmount);
            });
        }

        private void AddThreeTransactionWithDiferentStatus()
        {
            this.chainblock.Add(new Transaction
            {
                Id = 1,
                From = "Kiko",
                To = "Mirko",
                Amount = 100,
                Status = TransactionStatus.Failed

            });
            this.chainblock.Add(new Transaction
            {
                Id = 2,
                From = "Kiko",
                To = "Mirko",
                Amount = 100,
                Status = TransactionStatus.Successfull

            });
            this.chainblock.Add(new Transaction
            {
                Id = 3,
                From = "Kiko",
                To = "Mirko",
                Amount = 100,
                Status = TransactionStatus.Aborted

            });
        }
        private void AddBulkOfTransaction()
        {
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                TransactionStatus status = TransactionStatus.Successfull;
                string from = "John";
                string to = "Koki";
                if (i % 2 == 0)
                {
                    status = TransactionStatus.Unauthorized;
                    from = "Ivan";
                    to = "Inna";
                }
                if (i % 3 == 0)
                {
                    status = TransactionStatus.Aborted;
                    from = "Koce";
                    to = "Peshi";
                }
                if (i % 5 == 0)
                {
                    status = TransactionStatus.Failed;
                    from = "Gogi";
                    to = "Aslan";
                }

                double amount = i % 2 == 0 ? 100 : 100 + i;

                 
                ITransaction transaction = new Transaction
                {
                    Id = n - i,
                    From = from,
                    To = to,
                    Amount = amount,
                    Status = status

                };

                this.chainblock.Add(transaction);
            }
        }
        private ITransaction CreateSimpleTransaction()
        {
            return new Transaction

            {
                Id = 1,
                From = "Kiko",
                To = "Mirko",
                Amount = 100,
                Status = TransactionStatus.Successfull
            };
        }

    }
}
