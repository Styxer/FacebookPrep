using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacebookPrepForms.Accounts_Merge
{
    public static class Solution
    {
        static Dictionary<int, HashSet<string>> accountToEmail;
        static Dictionary<string, HashSet<int>> emailToAccount;

		static Solution()
		{
			accountToEmail = new Dictionary<int, HashSet<string>>();
			emailToAccount = new Dictionary<string, HashSet<int>>();
		}

		public static IList<IList<string>> AccountsMerge(IList<IList<string>> accounts)
		{
			var result = new List<IList<string>>();
			if (accounts == null || accounts.Count == 0)
				return result;

			for (int i = 0; i < accounts.Count; i++)
			{
				if (!accountToEmail.ContainsKey(i))
					accountToEmail.Add(i, new HashSet<string>());

				for (int j = 1; j < accounts[i].Count; j++)
				{
					string email = accounts[i][j];
					accountToEmail[i].Add(email);
					if (!emailToAccount.ContainsKey(email))
						emailToAccount.Add(email, new HashSet<int>());

					emailToAccount[email].Add(i);
				}
			}

			var visitedAccounts = new HashSet<int>();
			for (int i = 0; i < accounts.Count; i++)
			{
				if (visitedAccounts.Contains(i))
					continue;

				var name = accounts[i][0];
				var singleAccountEmails = new HashSet<string>();
				DFS(i, singleAccountEmails, visitedAccounts);
				var emailIds = singleAccountEmails.ToList();
				emailIds.Sort(StringComparer.Ordinal);
				emailIds.Insert(0, name);
				result.Add(emailIds);
			}

			return result;
		}

		private static void DFS(int account, HashSet<string> singleAccountEmails, HashSet<int> visitedAccounts)
		{
			if (visitedAccounts.Contains(account))
				return;

			visitedAccounts.Add(account);
			var emails = accountToEmail[account];
			foreach (var email in emails)
			{
				singleAccountEmails.Add(email);
				HashSet<int> accounts = emailToAccount[email];
				foreach (int acc in accounts)
				{
					if (visitedAccounts.Contains(acc))
						continue;

					DFS(acc, singleAccountEmails, visitedAccounts);
				}
			}
		}
	}
}
