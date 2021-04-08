using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bankVault;
        [SetUp]
        public void Setup()
        {
            this.item = new Item("Mirko","P2340") ;
            this.bankVault = new BankVault();
        }

        [Test]
        public void AddItemShloudThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("A12",this.item));
        }
        [Test]
        public void AddItemShloudThrowExceptionWhenCellIsNotEmpty()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<ArgumentException>(() => this.bankVault.AddItem("A1", new Item("A234","@25")));
        }
        [Test]
        public void AddItemShloudThrowExceptionWhenItemIsAleradyExisting()
        {
            this.bankVault.AddItem("A1", this.item);
            Assert.Throws<InvalidOperationException>(() => this.bankVault.AddItem("A2", this.item));
        }
        [Test]
        public void RemoveItemShloudThrowException()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("A12", this.item));
        }
        [Test]
        public void RemoveItemShloudThrowExceptionWhenItemDoesNotExist()
        {
            Assert.Throws<ArgumentException>(() => this.bankVault.RemoveItem("A1", this.item));
        }
        [Test]
        public void RemoveItedShouldWorkCorect()
        {
            this.bankVault.AddItem("A1", this.item);
            this.bankVault.RemoveItem("A1", this.item);
            Assert.IsNull(this.bankVault.VaultCells["A1"]);
        }
    }
}