﻿namespace RavenCodeSamples.ClientApi.Advanced
{
	using System.Transactions;

	public class TransactionSupport : CodeSampleBase
	{
		public void Transaction()
		{
			using (var store = NewDocumentStore())
			{
				using (var session = store.OpenSession())
				{
					#region transaction_support_1
					using (var transaction = new TransactionScope())
					{
						BlogPost entity = session.Load<BlogPost>("blogs/1");

						entity.Title = "Some new title";

						session.SaveChanges(); // will create HTTP request

						session.Delete(entity);

						session.SaveChanges(); // will create HTTP request

						transaction.Complete(); // will commit transaction
					}
					#endregion
				}
			}
		}
	}
}