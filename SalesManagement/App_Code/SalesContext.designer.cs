﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;



[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Sales")]
public partial class SalesContextDataContext : System.Data.Linq.DataContext
{
	
	private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
	
  #region Extensibility Method Definitions
  partial void OnCreated();
  partial void InsertAccount(Account instance);
  partial void UpdateAccount(Account instance);
  partial void DeleteAccount(Account instance);
  partial void InsertUserInRole(UserInRole instance);
  partial void UpdateUserInRole(UserInRole instance);
  partial void DeleteUserInRole(UserInRole instance);
  partial void InsertProduct(Product instance);
  partial void UpdateProduct(Product instance);
  partial void DeleteProduct(Product instance);
  #endregion
	
	public SalesContextDataContext() : 
			base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SalesConnectionString"].ConnectionString, mappingSource)
	{
		OnCreated();
	}
	
	public SalesContextDataContext(string connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public SalesContextDataContext(System.Data.IDbConnection connection) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public SalesContextDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public SalesContextDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		OnCreated();
	}
	
	public System.Data.Linq.Table<Account> Accounts
	{
		get
		{
			return this.GetTable<Account>();
		}
	}
	
	public System.Data.Linq.Table<UserInRole> UserInRoles
	{
		get
		{
			return this.GetTable<UserInRole>();
		}
	}
	
	public System.Data.Linq.Table<Product> Products
	{
		get
		{
			return this.GetTable<Product>();
		}
	}
	
	[global::System.Data.Linq.Mapping.FunctionAttribute(Name="dbo.sp_UserInRoles")]
	public ISingleResult<sp_UserInRolesResult> sp_UserInRoles([global::System.Data.Linq.Mapping.ParameterAttribute(Name="UserID", DbType="Int")] System.Nullable<int> userID)
	{
		IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())), userID);
		return ((ISingleResult<sp_UserInRolesResult>)(result.ReturnValue));
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Account")]
public partial class Account : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _FullName;
	
	private string _UserName;
	
	private string _Password;
	
	private System.Nullable<System.DateTime> _JoinDate;
	
	private System.Nullable<System.DateTime> _ExitDate;
	
	private System.Nullable<bool> _IsAdmin;
	
	private System.Nullable<bool> _IsManager;
	
	private System.Nullable<bool> _IsUser;
	
	private System.Nullable<System.DateTime> _CreatedOn;
	
	private System.Nullable<int> _CreatedBy;
	
	private EntitySet<UserInRole> _UserInRoles;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnFullNameChanging(string value);
    partial void OnFullNameChanged();
    partial void OnUserNameChanging(string value);
    partial void OnUserNameChanged();
    partial void OnPasswordChanging(string value);
    partial void OnPasswordChanged();
    partial void OnJoinDateChanging(System.Nullable<System.DateTime> value);
    partial void OnJoinDateChanged();
    partial void OnExitDateChanging(System.Nullable<System.DateTime> value);
    partial void OnExitDateChanged();
    partial void OnIsAdminChanging(System.Nullable<bool> value);
    partial void OnIsAdminChanged();
    partial void OnIsManagerChanging(System.Nullable<bool> value);
    partial void OnIsManagerChanged();
    partial void OnIsUserChanging(System.Nullable<bool> value);
    partial void OnIsUserChanged();
    partial void OnCreatedOnChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedOnChanged();
    partial void OnCreatedByChanging(System.Nullable<int> value);
    partial void OnCreatedByChanged();
    #endregion
	
	public Account()
	{
		this._UserInRoles = new EntitySet<UserInRole>(new Action<UserInRole>(this.attach_UserInRoles), new Action<UserInRole>(this.detach_UserInRoles));
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_FullName", DbType="VarChar(100)")]
	public string FullName
	{
		get
		{
			return this._FullName;
		}
		set
		{
			if ((this._FullName != value))
			{
				this.OnFullNameChanging(value);
				this.SendPropertyChanging();
				this._FullName = value;
				this.SendPropertyChanged("FullName");
				this.OnFullNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserName", DbType="VarChar(100)")]
	public string UserName
	{
		get
		{
			return this._UserName;
		}
		set
		{
			if ((this._UserName != value))
			{
				this.OnUserNameChanging(value);
				this.SendPropertyChanging();
				this._UserName = value;
				this.SendPropertyChanged("UserName");
				this.OnUserNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Password", DbType="VarChar(30)")]
	public string Password
	{
		get
		{
			return this._Password;
		}
		set
		{
			if ((this._Password != value))
			{
				this.OnPasswordChanging(value);
				this.SendPropertyChanging();
				this._Password = value;
				this.SendPropertyChanged("Password");
				this.OnPasswordChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_JoinDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> JoinDate
	{
		get
		{
			return this._JoinDate;
		}
		set
		{
			if ((this._JoinDate != value))
			{
				this.OnJoinDateChanging(value);
				this.SendPropertyChanging();
				this._JoinDate = value;
				this.SendPropertyChanged("JoinDate");
				this.OnJoinDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ExitDate", DbType="DateTime")]
	public System.Nullable<System.DateTime> ExitDate
	{
		get
		{
			return this._ExitDate;
		}
		set
		{
			if ((this._ExitDate != value))
			{
				this.OnExitDateChanging(value);
				this.SendPropertyChanging();
				this._ExitDate = value;
				this.SendPropertyChanged("ExitDate");
				this.OnExitDateChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAdmin", DbType="Bit")]
	public System.Nullable<bool> IsAdmin
	{
		get
		{
			return this._IsAdmin;
		}
		set
		{
			if ((this._IsAdmin != value))
			{
				this.OnIsAdminChanging(value);
				this.SendPropertyChanging();
				this._IsAdmin = value;
				this.SendPropertyChanged("IsAdmin");
				this.OnIsAdminChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsManager", DbType="Bit")]
	public System.Nullable<bool> IsManager
	{
		get
		{
			return this._IsManager;
		}
		set
		{
			if ((this._IsManager != value))
			{
				this.OnIsManagerChanging(value);
				this.SendPropertyChanging();
				this._IsManager = value;
				this.SendPropertyChanged("IsManager");
				this.OnIsManagerChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsUser", DbType="Bit")]
	public System.Nullable<bool> IsUser
	{
		get
		{
			return this._IsUser;
		}
		set
		{
			if ((this._IsUser != value))
			{
				this.OnIsUserChanging(value);
				this.SendPropertyChanging();
				this._IsUser = value;
				this.SendPropertyChanged("IsUser");
				this.OnIsUserChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedOn
	{
		get
		{
			return this._CreatedOn;
		}
		set
		{
			if ((this._CreatedOn != value))
			{
				this.OnCreatedOnChanging(value);
				this.SendPropertyChanging();
				this._CreatedOn = value;
				this.SendPropertyChanged("CreatedOn");
				this.OnCreatedOnChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int")]
	public System.Nullable<int> CreatedBy
	{
		get
		{
			return this._CreatedBy;
		}
		set
		{
			if ((this._CreatedBy != value))
			{
				this.OnCreatedByChanging(value);
				this.SendPropertyChanging();
				this._CreatedBy = value;
				this.SendPropertyChanged("CreatedBy");
				this.OnCreatedByChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Account_UserInRole", Storage="_UserInRoles", ThisKey="Id", OtherKey="UserID")]
	public EntitySet<UserInRole> UserInRoles
	{
		get
		{
			return this._UserInRoles;
		}
		set
		{
			this._UserInRoles.Assign(value);
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
	
	private void attach_UserInRoles(UserInRole entity)
	{
		this.SendPropertyChanging();
		entity.Account = this;
	}
	
	private void detach_UserInRoles(UserInRole entity)
	{
		this.SendPropertyChanging();
		entity.Account = null;
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.UserInRole")]
public partial class UserInRole : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private System.Nullable<int> _UserID;
	
	private System.Nullable<int> _RoleID;
	
	private EntityRef<Account> _Account;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnUserIDChanging(System.Nullable<int> value);
    partial void OnUserIDChanged();
    partial void OnRoleIDChanging(System.Nullable<int> value);
    partial void OnRoleIDChanged();
    #endregion
	
	public UserInRole()
	{
		this._Account = default(EntityRef<Account>);
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UserID", DbType="Int")]
	public System.Nullable<int> UserID
	{
		get
		{
			return this._UserID;
		}
		set
		{
			if ((this._UserID != value))
			{
				if (this._Account.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnUserIDChanging(value);
				this.SendPropertyChanging();
				this._UserID = value;
				this.SendPropertyChanged("UserID");
				this.OnUserIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleID", DbType="Int")]
	public System.Nullable<int> RoleID
	{
		get
		{
			return this._RoleID;
		}
		set
		{
			if ((this._RoleID != value))
			{
				this.OnRoleIDChanging(value);
				this.SendPropertyChanging();
				this._RoleID = value;
				this.SendPropertyChanged("RoleID");
				this.OnRoleIDChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Account_UserInRole", Storage="_Account", ThisKey="UserID", OtherKey="Id", IsForeignKey=true)]
	public Account Account
	{
		get
		{
			return this._Account.Entity;
		}
		set
		{
			Account previousValue = this._Account.Entity;
			if (((previousValue != value) 
						|| (this._Account.HasLoadedOrAssignedValue == false)))
			{
				this.SendPropertyChanging();
				if ((previousValue != null))
				{
					this._Account.Entity = null;
					previousValue.UserInRoles.Remove(this);
				}
				this._Account.Entity = value;
				if ((value != null))
				{
					value.UserInRoles.Add(this);
					this._UserID = value.Id;
				}
				else
				{
					this._UserID = default(Nullable<int>);
				}
				this.SendPropertyChanged("Account");
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Product")]
public partial class Product : INotifyPropertyChanging, INotifyPropertyChanged
{
	
	private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
	
	private int _Id;
	
	private string _ProductName;
	
	private int _Quantity;
	
	private double _UnitPrice;
	
	private System.Nullable<System.DateTime> _CreatedOn;
	
	private System.Nullable<int> _CreatedBy;
	
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(int value);
    partial void OnIdChanged();
    partial void OnProductNameChanging(string value);
    partial void OnProductNameChanged();
    partial void OnQuantityChanging(int value);
    partial void OnQuantityChanged();
    partial void OnUnitPriceChanging(double value);
    partial void OnUnitPriceChanged();
    partial void OnCreatedOnChanging(System.Nullable<System.DateTime> value);
    partial void OnCreatedOnChanged();
    partial void OnCreatedByChanging(System.Nullable<int> value);
    partial void OnCreatedByChanged();
    #endregion
	
	public Product()
	{
		OnCreated();
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
	public int Id
	{
		get
		{
			return this._Id;
		}
		set
		{
			if ((this._Id != value))
			{
				this.OnIdChanging(value);
				this.SendPropertyChanging();
				this._Id = value;
				this.SendPropertyChanged("Id");
				this.OnIdChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ProductName", DbType="VarChar(100)")]
	public string ProductName
	{
		get
		{
			return this._ProductName;
		}
		set
		{
			if ((this._ProductName != value))
			{
				this.OnProductNameChanging(value);
				this.SendPropertyChanging();
				this._ProductName = value;
				this.SendPropertyChanged("ProductName");
				this.OnProductNameChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Quantity", DbType="Int NOT NULL")]
	public int Quantity
	{
		get
		{
			return this._Quantity;
		}
		set
		{
			if ((this._Quantity != value))
			{
				this.OnQuantityChanging(value);
				this.SendPropertyChanging();
				this._Quantity = value;
				this.SendPropertyChanged("Quantity");
				this.OnQuantityChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_UnitPrice", DbType="Float NOT NULL")]
	public double UnitPrice
	{
		get
		{
			return this._UnitPrice;
		}
		set
		{
			if ((this._UnitPrice != value))
			{
				this.OnUnitPriceChanging(value);
				this.SendPropertyChanging();
				this._UnitPrice = value;
				this.SendPropertyChanged("UnitPrice");
				this.OnUnitPriceChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedOn", DbType="DateTime")]
	public System.Nullable<System.DateTime> CreatedOn
	{
		get
		{
			return this._CreatedOn;
		}
		set
		{
			if ((this._CreatedOn != value))
			{
				this.OnCreatedOnChanging(value);
				this.SendPropertyChanging();
				this._CreatedOn = value;
				this.SendPropertyChanged("CreatedOn");
				this.OnCreatedOnChanged();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_CreatedBy", DbType="Int")]
	public System.Nullable<int> CreatedBy
	{
		get
		{
			return this._CreatedBy;
		}
		set
		{
			if ((this._CreatedBy != value))
			{
				this.OnCreatedByChanging(value);
				this.SendPropertyChanging();
				this._CreatedBy = value;
				this.SendPropertyChanged("CreatedBy");
				this.OnCreatedByChanged();
			}
		}
	}
	
	public event PropertyChangingEventHandler PropertyChanging;
	
	public event PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		if ((this.PropertyChanging != null))
		{
			this.PropertyChanging(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(String propertyName)
	{
		if ((this.PropertyChanged != null))
		{
			this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}

public partial class sp_UserInRolesResult
{
	
	private string _RoleName;
	
	public sp_UserInRolesResult()
	{
	}
	
	[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_RoleName", DbType="VarChar(100)")]
	public string RoleName
	{
		get
		{
			return this._RoleName;
		}
		set
		{
			if ((this._RoleName != value))
			{
				this._RoleName = value;
			}
		}
	}
}
#pragma warning restore 1591
