using Chainblock.Contracts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chainblock
{
    public class Chainblock : IChainblock
    {
        private readonly Dictionary<int, ITransaction> transactionById;

        public Chainblock()
        {
            this.transactionById = new Dictionary<int, ITransaction>();
        }
        public int Count => this.transactionById.Count;

        public void Add(ITransaction tx)
        {
            if (this.Contains(tx.Id))
            {
                throw new InvalidOperationException($"Transaction with id: {tx.Id} already exists.");
            }

            this.transactionById.Add(tx.Id, tx);
        }

        public void ChangeTransactionStatus(int id, TransactionStatus newStatus)
        {
            if (!this.Contains(id))
            {
                throw new ArgumentException($"{id} id does not exist.");
            }

            ITransaction transaction = this.transactionById[id];
            transaction.Status = newStatus;
        }

        public bool Contains(ITransaction tx)
        {
            if (!this.Contains(tx.Id))
            {
                return false;
            }
            ITransaction existingTransaction = this.transactionById[tx.Id];

            return tx.From == existingTransaction.From &&
                   tx.To == existingTransaction.To &&
                   tx.Status == existingTransaction.Status &&
                   tx.Amount == existingTransaction.Amount;
        }

        public bool Contains(int id)
        {
            return this.transactionById.ContainsKey(id);
        }

        public IEnumerable<ITransaction> GetAllInAmountRange(double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ITransaction> GetAllOrderedByAmountDescendingThenById()
        {
            return this.transactionById.Values.OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();
        }

        public IEnumerable<string> GetAllReceiversWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionById.Values.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.To).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }
            return result;
        }

        public IEnumerable<string> GetAllSendersWithTransactionStatus(TransactionStatus status)
        {
            List<string> result = this.transactionById.Values.Where(t => t.Status == status).OrderBy(t => t.Amount).Select(t => t.From).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }
           return result;
        }

        public ITransaction GetById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with {id} does not exist.");
            }

            return this.transactionById[id];
        }

        public IEnumerable<ITransaction> GetByReceiverAndAmountRange(string receiver, double lo, double hi)
        {
            List<ITransaction> result = this.transactionById.Values.Where(t => t.To == receiver && t.Amount >= lo && t.Amount <= hi).OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByReceiverOrderedByAmountThenById(string receiver)
        {
            List<ITransaction> result = this.transactionById.Values.Where(t => t.To == receiver).OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderAndMinimumAmountDescending(string sender, double amount)
        {
            List<ITransaction> result  = this.transactionById.Values.Where(t => t.From == sender && t.Amount > amount).OrderByDescending(t => t.Amount).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetBySenderOrderedByAmountDescending(string sender)
        {
            List<ITransaction> result = this.transactionById.Values.Where(t => t.From == sender).OrderByDescending(t => t.Amount).ThenBy(t => t.Id).ToList();

            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;

        }

        public IEnumerable<ITransaction> GetByTransactionStatus(TransactionStatus status)
        {
            List<ITransaction> result = this.transactionById
                .Values
                .Where(t => t.Status == status)
                .OrderByDescending(t => t.Amount)
                .ToList();
            if (result.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return result;
        }

        public IEnumerable<ITransaction> GetByTransactionStatusAndMaximumAmount(TransactionStatus status, double amount)
        {
            return this.transactionById.Values.Where(t => t.Status == status && t.Amount <= amount).OrderByDescending(t => t.Amount);
        }

        public IEnumerator<ITransaction> GetEnumerator()
        {
            foreach (var transaction in this.transactionById)
            {
                yield return transaction.Value;
            }
        }

        public void RemoveTransactionById(int id)
        {
            if (!this.Contains(id))
            {
                throw new InvalidOperationException($"Transaction with {id} does not exist.");
            }
            this.transactionById.Remove(id);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
