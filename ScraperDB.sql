USE [ScraperV4]
GO
/****** Object:  Table [dbo].[finviz_Calendar]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[finviz_Calendar](
	[finviz_calendar_id] [bigint] IDENTITY(1,1) NOT NULL,
	[job_run_id] [int] NOT NULL,
	[calendar_date_text] [varchar](30) NULL,
	[calendar_yyyy] [varchar](5) NULL,
	[calendar_mm] [varchar](5) NULL,
	[calendar_dd] [varchar](5) NULL,
	[calendar_day] [varchar](5) NULL,
	[banner_date] [varchar](50) NOT NULL,
	[time_zone] [varchar](6) NULL,
	[calendar_date] [varchar](30) NOT NULL,
	[market_closed] [bit] NULL,
	[official_market_closure] [bit] NULL,
	[market_closure_notes] [nvarchar](1027) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_finviz_Calendar] PRIMARY KEY CLUSTERED 
(
	[finviz_calendar_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[finviz_Financials]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[finviz_Financials](
	[Finviz_FinancialId] [bigint] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_Id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NOT NULL,
	[value] [nvarchar](50) NULL,
	[descriptor] [nvarchar](50) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_FinvizFinancials] PRIMARY KEY CLUSTERED 
(
	[Finviz_FinancialId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[finviz_Insider_Trading]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[finviz_Insider_Trading](
	[Finviz_Insider_TradingId] [bigint] IDENTITY(1,1) NOT NULL,
	[stock_Id] [int] NOT NULL,
	[Job_run_Id] [int] NOT NULL,
	[EffectiveDate] [nvarchar](50) NOT NULL,
	[insider_Trading] [nvarchar](127) NULL,
	[relationship] [nvarchar](127) NULL,
	[Date] [nvarchar](63) NULL,
	[it_transaction] [nvarchar](63) NULL,
	[cost] [nvarchar](63) NULL,
	[shares] [nvarchar](63) NULL,
	[value] [nvarchar](63) NULL,
	[shares_Total] [nvarchar](63) NULL,
	[SEC_Form_4] [nvarchar](63) NULL,
	[CreatedOn] [timestamp] NULL,
 CONSTRAINT [PK_finviz_Insider_Trading] PRIMARY KEY CLUSTERED 
(
	[Finviz_Insider_TradingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[finviz_Market_Movers]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[finviz_Market_Movers](
	[finviz_market_movers_id] [bigint] IDENTITY(1,1) NOT NULL,
	[stock_id] [int] NOT NULL,
	[job_run_id] [int] NOT NULL,
	[EffectiveDate] [nvarchar](30) NULL,
	[ticker] [nvarchar](50) NULL,
	[last_quote] [decimal](9, 2) NULL,
	[percent_change] [decimal](5, 2) NULL,
	[volume] [int] NULL,
	[signal] [nvarchar](50) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_finviz_MARKET_MOVERS] PRIMARY KEY CLUSTERED 
(
	[finviz_market_movers_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[finviz_News]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[finviz_News](
	[finviz_news_id] [bigint] IDENTITY(1,1) NOT NULL,
	[stock_id] [int] NOT NULL,
	[job_run_id] [int] NOT NULL,
	[news_date] [nvarchar](23) NOT NULL,
	[news_message] [nvarchar](max) NULL,
	[news_link] [nvarchar](max) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_News_1] PRIMARY KEY CLUSTERED 
(
	[finviz_news_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[finviz_Recommendations]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[finviz_Recommendations](
	[finviz_recommendationId] [bigint] IDENTITY(1,1) NOT NULL,
	[job_run_id] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[EffectiveDate] [nvarchar](50) NOT NULL,
	[Date] [nvarchar](50) NULL,
	[RecommendationType] [nvarchar](100) NULL,
	[Analyst] [nvarchar](100) NULL,
	[Recommendation] [nvarchar](100) NULL,
	[Target] [nvarchar](100) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_finviz_Recommendations_1] PRIMARY KEY CLUSTERED 
(
	[finviz_recommendationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ft_Consensus]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ft_Consensus](
	[ConsensusId] [bigint] IDENTITY(1,1) NOT NULL,
	[job_run_id] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[effective_date] [varchar](30) NOT NULL,
	[consensus] [varchar](max) NULL,
	[buy_analyst_count] [smallint] NULL,
	[outperform_analyst_count] [smallint] NULL,
	[hold_analyst_count] [smallint] NULL,
	[underperform_analyst_count] [smallint] NULL,
	[sell_analyst_count] [smallint] NULL,
	[no_opinion_analyst_count] [smallint] NULL,
	[CreatedOn] [timestamp] NULL,
 CONSTRAINT [PK_finviz_Recommendations] PRIMARY KEY CLUSTERED 
(
	[ConsensusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ft_Financials]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ft_Financials](
	[financial_id] [bigint] IDENTITY(1,1) NOT NULL,
	[job_run_id] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[effective_date] [varchar](17) NOT NULL,
	[year] [char](4) NULL,
	[ragp_total_revenue] [decimal](18, 2) NULL,
	[oe_cost_of_revenue_total] [decimal](18, 2) NULL,
	[oe_selling_generalexpenses_total] [decimal](18, 2) NULL,
	[oe_depreciation_amort] [decimal](18, 2) NULL,
	[oe_unusual_expense_income] [decimal](18, 2) NULL,
	[oe_other_operating_expenses_total] [decimal](18, 2) NULL,
	[oe_total_operating_expense] [decimal](18, 2) NULL,
	[oe_operating_income] [decimal](18, 2) NULL,
	[oe_other_net] [decimal](18, 2) NULL,
	[itmiei_net_income_before_taxes] [decimal](18, 2) NULL,
	[itmiei_provision_for_income_taxes] [decimal](18, 2) NULL,
	[itmiei_net_income_after_taxes] [decimal](18, 2) NULL,
	[itmiei_minority_interest] [decimal](18, 2) NULL,
	[itmiei_net_income_before_extra_items] [decimal](18, 2) NULL,
	[itmiei_total_extraordinary_items] [decimal](18, 2) NULL,
	[itmiei_net_income] [decimal](18, 2) NULL,
	[itmiei_inc_to_common_excl_extra_items] [decimal](18, 2) NULL,
	[itmiei_inc_to_common_incl_extra_items] [decimal](18, 2) NULL,
	[epsr_basic_weighted_average_shares] [decimal](18, 2) NULL,
	[epsr_basic_eps_excl_extra_items] [decimal](18, 2) NULL,
	[epsr_basic_eps_incl_extra_items] [decimal](18, 2) NULL,
	[epsr_dilution_adjustment] [decimal](18, 2) NULL,
	[epsr_diluted_weighted_average_shares] [decimal](18, 2) NULL,
	[epsr_diluted_eps_excl_extra_items] [decimal](18, 2) NULL,
	[epsr_diluted_eps_incl_extra_items] [decimal](18, 2) NULL,
	[csd_dps_common_stock_primary_issue] [decimal](18, 2) NULL,
	[csd_gross_dividend_common_stock] [decimal](18, 2) NULL,
	[pfi_pro_forma_net_income] [decimal](18, 2) NULL,
	[pfi_interest_expense_supplemental] [decimal](18, 2) NULL,
	[si_depreciation_supplemental] [decimal](18, 2) NULL,
	[si_total_special_items] [decimal](18, 2) NULL,
	[ni_normalized_income_before_taxes] [decimal](18, 2) NULL,
	[ni_effect_of_special_items_on_income_taxes] [decimal](18, 2) NULL,
	[ni_income_tax_excluding_impact_of_special_items] [decimal](18, 2) NULL,
	[ni_normalized_income_after_tax] [decimal](18, 2) NULL,
	[ni_normalized_income_avail_to_common] [decimal](18, 2) NULL,
	[ni_basic_normalized_eps] [decimal](18, 2) NULL,
	[ni_diluted_normalized_eps] [decimal](18, 2) NULL,
	[created_on] [timestamp] NOT NULL,
 CONSTRAINT [PK_ft_Financials] PRIMARY KEY CLUSTERED 
(
	[financial_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ft_Forecasts]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ft_Forecasts](
	[forecast_id] [bigint] IDENTITY(1,1) NOT NULL,
	[job_run_id] [int] NOT NULL,
	[stock_id] [int] NOT NULL,
	[effective_date] [varchar](30) NOT NULL,
	[forecast_description] [varchar](max) NULL,
	[current_price] [decimal](9, 2) NULL,
	[high_target_price] [decimal](9, 2) NULL,
	[medium_target_price] [decimal](9, 2) NULL,
	[low_target_price] [decimal](9, 2) NULL,
	[time_period_unit] [nvarchar](50) NULL,
	[time_period] [smallint] NULL,
	[CreatedOn] [timestamp] NULL,
 CONSTRAINT [PK_ft_Forecasts] PRIMARY KEY CLUSTERED 
(
	[forecast_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_Financials_Dividends]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reuters_Financials_Dividends](
	[Reuters_FinancialsDividend_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[run_job_Id] [int] NOT NULL,
	[EffectiveDate] [nvarchar](30) NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[Sector] [nvarchar](50) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_Dividends] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsDividend_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reuters_Financials_Efficiencies]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reuters_Financials_Efficiencies](
	[Reuters_FinancialsEfficiency_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[run_job_id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[Sector] [nvarchar](100) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_Efficiencies] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsEfficiency_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_Financials_GrowthRates]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reuters_Financials_GrowthRates](
	[Reuters_FinancialsGrowthRate_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[run_job_id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Sector] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_GrowthRates] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsGrowthRate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_Financials_Institutions]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reuters_Financials_Institutions](
	[Reuters_FinancialsInstitutions_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[DataValue] [nvarchar](100) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_Institutions] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsInstitutions_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_Financials_MgmtEffectiveness]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reuters_Financials_MgmtEffectiveness](
	[Reuters_FinancialsMgmtEffectiveness_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_Id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[Sector] [nvarchar](100) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_MgmtEffectiveness] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsMgmtEffectiveness_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_Financials_ProfitabilityRatios]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reuters_Financials_ProfitabilityRatios](
	[Reuters_Financials_ProfitabilityRatios_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[Job_run_Id] [int] NOT NULL,
	[EffectiveDate] [nvarchar](50) NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](50) NULL,
	[Industry] [nvarchar](50) NULL,
	[Sector] [nvarchar](50) NULL,
	[CreatedOn] [timestamp] NULL,
 CONSTRAINT [PK_reuters_Financials_ProfitabilityRatios] PRIMARY KEY CLUSTERED 
(
	[Reuters_Financials_ProfitabilityRatios_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reuters_Financials_SalesEstimates]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reuters_Financials_SalesEstimates](
	[Reuters_FinancialsSalesEstimates_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_id] [int] NOT NULL,
	[EffectiveDate] [nvarchar](30) NULL,
	[Title] [nvarchar](100) NULL,
	[Estimates] [nvarchar](50) NULL,
	[Mean] [nvarchar](50) NULL,
	[High] [nvarchar](50) NULL,
	[Low] [nvarchar](50) NULL,
	[Sale_Type] [smallint] NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_SalesEstimates] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsSalesEstimates_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reuters_Financials_Strength]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reuters_Financials_Strength](
	[Reuters_FinancialsStrength_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_Id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Industry] [nvarchar](100) NULL,
	[Sector] [nvarchar](100) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_Strength] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsStrength_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_Financials_ValuationRatios]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[reuters_Financials_ValuationRatios](
	[Reuters_FinancialsValuationRatio_Id] [int] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_Id] [int] NOT NULL,
	[EffectiveDate] [varchar](30) NOT NULL,
	[Title] [nvarchar](100) NULL,
	[Company] [nvarchar](100) NULL,
	[Industry] [nvarchar](50) NULL,
	[Sector] [nvarchar](50) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Reuters_Financials_ValuationRatios] PRIMARY KEY CLUSTERED 
(
	[Reuters_FinancialsValuationRatio_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[reuters_RecommendationsRevisions]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reuters_RecommendationsRevisions](
	[Reuters_RecommendationsRevisions_Id] [bigint] IDENTITY(1,1) NOT NULL,
	[Stock_Id] [int] NOT NULL,
	[job_run_Id] [int] NOT NULL,
	[LastRecommendationDate] [date] NULL,
	[Linear_Scale] [nvarchar](max) NULL,
	[AnalystRecommend_Current] [nvarchar](max) NULL,
	[AnalystRecommend_Month_1] [nvarchar](max) NULL,
	[AnalystRecommend_Month_2] [nvarchar](max) NULL,
	[AnalystRecommend_Month_3] [nvarchar](max) NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_AnalyticsRecommendationsRevisions] PRIMARY KEY CLUSTERED 
(
	[Reuters_RecommendationsRevisions_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_JobRuns]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_JobRuns](
	[run_id] [int] IDENTITY(1,1) NOT NULL,
	[job_run_id] [int] NOT NULL,
	[web_calls_total] [int] NOT NULL,
	[web_calls_success] [int] NOT NULL,
	[web_calls_failures] [int] NOT NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_ws_JobRuns] PRIMARY KEY CLUSTERED 
(
	[run_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_Jobs]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_Jobs](
	[Job_id] [int] IDENTITY(1,1) NOT NULL,
	[scheduler_id] [int] NOT NULL,
	[Start_Time] [datetime] NOT NULL,
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Jobs] PRIMARY KEY CLUSTERED 
(
	[Job_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_JobScheduler]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_JobScheduler](
	[scheduler_id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](150) NOT NULL,
	[description] [nvarchar](250) NULL,
	[jobtype_id] [int] NOT NULL,
	[start_date] [date] NOT NULL,
	[start_time] [time](7) NOT NULL,
	[end_date] [date] NULL,
	[end_time] [time](7) NULL,
	[schedulertype_id] [int] NOT NULL,
	[current_run_count] [int] NOT NULL CONSTRAINT [DF_ws_JobScheduler_current_run_count]  DEFAULT ((0)),
	[max_run_count] [int] NOT NULL CONSTRAINT [DF_ws_JobScheduler_max_run]  DEFAULT ((0)),
	[Status] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Status]  DEFAULT ((1)),
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_ws_JobScheduler] PRIMARY KEY CLUSTERED 
(
	[scheduler_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_JobScheduler_Daily]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_JobScheduler_Daily](
	[schedule_daily_id] [int] IDENTITY(1,1) NOT NULL,
	[scheduler_id] [int] NOT NULL,
	[recur_days] [int] NOT NULL,
	[IsWeekDay] [bit] NULL CONSTRAINT [DF_ws_JobScheduler_Daily_IsWeekDay]  DEFAULT ((0)),
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_ws_JobScheduler_Daily] PRIMARY KEY CLUSTERED 
(
	[schedule_daily_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_JobScheduler_Monthly]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_JobScheduler_Monthly](
	[scheduler_monthly_id] [int] IDENTITY(1,1) NOT NULL,
	[schedulder_id] [int] NOT NULL,
	[monthly_nominal_day] [int] NOT NULL,
	[monthly_nominal_month] [int] NOT NULL,
	[monthly_day] [int] NOT NULL,
	[monthly_week_of_day] [int] NOT NULL,
	[monthly_freq] [int] NOT NULL,
	[monthly_isweekday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Monthly_monthly_isweekday]  DEFAULT ((0)),
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_ws_JobScheduler_Monthly] PRIMARY KEY CLUSTERED 
(
	[scheduler_monthly_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_JobScheduler_Weekly]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_JobScheduler_Weekly](
	[scheduler_weekly_id] [int] IDENTITY(1,1) NOT NULL,
	[scheduler_id] [int] NOT NULL,
	[weekly_freq] [int] NOT NULL,
	[weekly_sunday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Weekly_weekly_sunday]  DEFAULT ((0)),
	[weekly_monday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Weekly_weekly_monday]  DEFAULT ((0)),
	[weekly_tuesday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Weekly_weekly_tuesday]  DEFAULT ((0)),
	[weekly_wednesday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Weekly_weekly_wednesday]  DEFAULT ((0)),
	[weekly_thursday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Weekly_weekly_thursday]  DEFAULT ((0)),
	[weekly_friday] [bit] NOT NULL,
	[weekly_saturday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Weekly_weekly_saturday]  DEFAULT ((0)),
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_ws_JobScheduler_Weekly] PRIMARY KEY CLUSTERED 
(
	[scheduler_weekly_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_JobScheduler_Yearly]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_JobScheduler_Yearly](
	[scheduler_yearly_id] [int] IDENTITY(1,1) NOT NULL,
	[scheduler_id] [int] NOT NULL,
	[yearly_nominal_day] [int] NOT NULL,
	[yearly_nominal_month] [int] NOT NULL,
	[yearly_day] [int] NOT NULL,
	[yearly_week_of_day] [int] NOT NULL,
	[yearly_month] [int] NOT NULL,
	[yearly_isweekday] [bit] NOT NULL CONSTRAINT [DF_ws_JobScheduler_Yearly_yearly_isweekday]  DEFAULT ((0)),
	[CreatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_ws_JobScheduler_Yearly] PRIMARY KEY CLUSTERED 
(
	[scheduler_yearly_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_Logs]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_Logs](
	[Log_Id] [int] IDENTITY(1,1) NOT NULL,
	[job_run_Id] [int] NOT NULL,
	[log_msg] [nvarchar](max) NULL,
	[log_status] [nvarchar](20) NULL,
	[CreatedOn] [timestamp] NULL,
 CONSTRAINT [PK_Logs_1] PRIMARY KEY CLUSTERED 
(
	[Log_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ws_Stocks]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ws_Stocks](
	[Stock_Id] [int] IDENTITY(1,1) NOT NULL,
	[Ticker] [nvarchar](50) NOT NULL,
	[Company_Name] [nvarchar](1280) NOT NULL,
	[Exchange] [nvarchar](128) NULL,
	[Sector] [nvarchar](128) NULL,
	[Industry] [nvarchar](128) NULL,
	[Exchange_Abbr] [nvarchar](50) NULL,
	[Exchange_Letter] [nvarchar](50) NULL,
	[Format_Issue_Symbol] [nvarchar](50) NULL,
	[StatusState_Id] [tinyint] NULL CONSTRAINT [DF_Stocks_StatusState_Id]  DEFAULT ((1)),
	[Source] [nvarchar](16) NULL,
	[company_desc_finviz] [nvarchar](max) NULL,
	[sub_sector] [nvarchar](50) NULL,
	[country] [nvarchar](50) NULL,
	[CreatedOn] [datetime] NULL CONSTRAINT [DF_Stocks_CreatedOn]  DEFAULT (getdate()),
	[UpdatedOn] [timestamp] NOT NULL,
 CONSTRAINT [PK_Stocks] PRIMARY KEY CLUSTERED 
(
	[Stock_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[wslu_JobSchedulerTypes]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wslu_JobSchedulerTypes](
	[schedulertype_id] [int] NOT NULL,
	[schedulartype_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_wslu_JobSchedulerTypes] PRIMARY KEY CLUSTERED 
(
	[schedulertype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[wslu_JobTypes]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[wslu_JobTypes](
	[jobtype_id] [int] NOT NULL,
	[jobtype_name] [nvarchar](100) NULL,
 CONSTRAINT [PK_wslu_JobTypes] PRIMARY KEY CLUSTERED 
(
	[jobtype_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[reuters_Financials_SalesEstimates] ADD  CONSTRAINT [DF_reuters_Financials_SalesEstimates_Sale_Type]  DEFAULT ((1)) FOR [Sale_Type]
GO
ALTER TABLE [dbo].[ws_Jobs] ADD  CONSTRAINT [DF_Table_1_StartTime]  DEFAULT (getdate()) FOR [Start_Time]
GO
ALTER TABLE [dbo].[ws_Logs] ADD  CONSTRAINT [DF_ws_Logs_log_status]  DEFAULT (N'Warning') FOR [log_status]
GO
ALTER TABLE [dbo].[finviz_Calendar]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_Calendar_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Calendar] NOCHECK CONSTRAINT [FK_finviz_Calendar_ws_Jobs]
GO
ALTER TABLE [dbo].[finviz_Financials]  WITH NOCHECK ADD  CONSTRAINT [FK_Finviz_Financials_Jobs] FOREIGN KEY([job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Financials] NOCHECK CONSTRAINT [FK_Finviz_Financials_Jobs]
GO
ALTER TABLE [dbo].[finviz_Financials]  WITH NOCHECK ADD  CONSTRAINT [FK_Finviz_Financials_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Financials] NOCHECK CONSTRAINT [FK_Finviz_Financials_Stocks]
GO
ALTER TABLE [dbo].[finviz_Insider_Trading]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_Insider_Trading_ws_Jobs] FOREIGN KEY([Job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Insider_Trading] NOCHECK CONSTRAINT [FK_finviz_Insider_Trading_ws_Jobs]
GO
ALTER TABLE [dbo].[finviz_Insider_Trading]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_Insider_Trading_ws_Stocks] FOREIGN KEY([stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Insider_Trading] NOCHECK CONSTRAINT [FK_finviz_Insider_Trading_ws_Stocks]
GO
ALTER TABLE [dbo].[finviz_Market_Movers]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_MARKET_MOVERS_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Market_Movers] NOCHECK CONSTRAINT [FK_finviz_MARKET_MOVERS_ws_Jobs]
GO
ALTER TABLE [dbo].[finviz_Market_Movers]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_Market_Movers_ws_Stocks] FOREIGN KEY([stock_id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Market_Movers] NOCHECK CONSTRAINT [FK_finviz_Market_Movers_ws_Stocks]
GO
ALTER TABLE [dbo].[finviz_News]  WITH NOCHECK ADD  CONSTRAINT [FK_News_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_News] NOCHECK CONSTRAINT [FK_News_Jobs]
GO
ALTER TABLE [dbo].[finviz_News]  WITH NOCHECK ADD  CONSTRAINT [FK_News_Stocks1] FOREIGN KEY([stock_id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_News] NOCHECK CONSTRAINT [FK_News_Stocks1]
GO
ALTER TABLE [dbo].[finviz_Recommendations]  WITH NOCHECK ADD  CONSTRAINT [FK_fin_Recommendations_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Recommendations] NOCHECK CONSTRAINT [FK_fin_Recommendations_ws_Jobs]
GO
ALTER TABLE [dbo].[finviz_Recommendations]  WITH NOCHECK ADD  CONSTRAINT [FK_fin_Recommendations_ws_Stocks] FOREIGN KEY([stock_id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[finviz_Recommendations] NOCHECK CONSTRAINT [FK_fin_Recommendations_ws_Stocks]
GO
ALTER TABLE [dbo].[ft_Consensus]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_Recommendations_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ft_Consensus] NOCHECK CONSTRAINT [FK_finviz_Recommendations_ws_Jobs]
GO
ALTER TABLE [dbo].[ft_Consensus]  WITH NOCHECK ADD  CONSTRAINT [FK_finviz_Recommendations_ws_Stocks] FOREIGN KEY([stock_id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ft_Consensus] NOCHECK CONSTRAINT [FK_finviz_Recommendations_ws_Stocks]
GO
ALTER TABLE [dbo].[ft_Financials]  WITH NOCHECK ADD  CONSTRAINT [FK_ft_Financials_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ft_Financials] NOCHECK CONSTRAINT [FK_ft_Financials_ws_Jobs]
GO
ALTER TABLE [dbo].[ft_Financials]  WITH NOCHECK ADD  CONSTRAINT [FK_ft_Financials_ws_Stocks] FOREIGN KEY([stock_id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ft_Financials] NOCHECK CONSTRAINT [FK_ft_Financials_ws_Stocks]
GO
ALTER TABLE [dbo].[ft_Forecasts]  WITH NOCHECK ADD  CONSTRAINT [FK_ft_Forecasts_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ft_Forecasts] NOCHECK CONSTRAINT [FK_ft_Forecasts_ws_Jobs]
GO
ALTER TABLE [dbo].[ft_Forecasts]  WITH NOCHECK ADD  CONSTRAINT [FK_ft_Forecasts_ws_Stocks] FOREIGN KEY([stock_id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ft_Forecasts] NOCHECK CONSTRAINT [FK_ft_Forecasts_ws_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_Dividends]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Dividends_Jobs] FOREIGN KEY([run_job_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Dividends] NOCHECK CONSTRAINT [FK_Reuters_Financials_Dividends_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_Dividends]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Dividends_Stocks1] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Dividends] NOCHECK CONSTRAINT [FK_Reuters_Financials_Dividends_Stocks1]
GO
ALTER TABLE [dbo].[reuters_Financials_Efficiencies]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Efficiencies_Jobs] FOREIGN KEY([run_job_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Efficiencies] NOCHECK CONSTRAINT [FK_Reuters_Financials_Efficiencies_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_Efficiencies]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Efficiencies_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Efficiencies] NOCHECK CONSTRAINT [FK_Reuters_Financials_Efficiencies_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_GrowthRates]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_GrowthRates_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_GrowthRates] NOCHECK CONSTRAINT [FK_Reuters_Financials_GrowthRates_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_GrowthRates]  WITH NOCHECK ADD  CONSTRAINT [FK_reuters_Financials_GrowthRates_ws_Jobs] FOREIGN KEY([run_job_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_GrowthRates] NOCHECK CONSTRAINT [FK_reuters_Financials_GrowthRates_ws_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_Institutions]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Institutions_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Institutions] NOCHECK CONSTRAINT [FK_Reuters_Financials_Institutions_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_Institutions]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Institutions_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Institutions] NOCHECK CONSTRAINT [FK_Reuters_Financials_Institutions_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_MgmtEffectiveness]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_MgmtEffectiveness_Jobs] FOREIGN KEY([job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_MgmtEffectiveness] NOCHECK CONSTRAINT [FK_Reuters_Financials_MgmtEffectiveness_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_MgmtEffectiveness]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_MgmtEffectiveness_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_MgmtEffectiveness] NOCHECK CONSTRAINT [FK_Reuters_Financials_MgmtEffectiveness_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_ProfitabilityRatios]  WITH NOCHECK ADD  CONSTRAINT [FK_reuters_Financials_ProfitabilityRatios_ws_Jobs] FOREIGN KEY([Job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_ProfitabilityRatios] NOCHECK CONSTRAINT [FK_reuters_Financials_ProfitabilityRatios_ws_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_ProfitabilityRatios]  WITH NOCHECK ADD  CONSTRAINT [FK_reuters_Financials_ProfitabilityRatios_ws_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_ProfitabilityRatios] NOCHECK CONSTRAINT [FK_reuters_Financials_ProfitabilityRatios_ws_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_SalesEstimates]  WITH NOCHECK ADD  CONSTRAINT [FK_reuters_Financials_SalesEstimates_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_SalesEstimates] NOCHECK CONSTRAINT [FK_reuters_Financials_SalesEstimates_ws_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_SalesEstimates]  WITH NOCHECK ADD  CONSTRAINT [FK_reuters_Financials_SalesEstimates_ws_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_SalesEstimates] NOCHECK CONSTRAINT [FK_reuters_Financials_SalesEstimates_ws_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_Strength]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Strength_Jobs] FOREIGN KEY([job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Strength] NOCHECK CONSTRAINT [FK_Reuters_Financials_Strength_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_Strength]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_Strength_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_Strength] NOCHECK CONSTRAINT [FK_Reuters_Financials_Strength_Stocks]
GO
ALTER TABLE [dbo].[reuters_Financials_ValuationRatios]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_ValuationRatios_Jobs] FOREIGN KEY([job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_ValuationRatios] NOCHECK CONSTRAINT [FK_Reuters_Financials_ValuationRatios_Jobs]
GO
ALTER TABLE [dbo].[reuters_Financials_ValuationRatios]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_Financials_ValuationRatios_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_Financials_ValuationRatios] NOCHECK CONSTRAINT [FK_Reuters_Financials_ValuationRatios_Stocks]
GO
ALTER TABLE [dbo].[reuters_RecommendationsRevisions]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_RecommendationsRevisions_Jobs] FOREIGN KEY([job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_RecommendationsRevisions] NOCHECK CONSTRAINT [FK_Reuters_RecommendationsRevisions_Jobs]
GO
ALTER TABLE [dbo].[reuters_RecommendationsRevisions]  WITH NOCHECK ADD  CONSTRAINT [FK_Reuters_RecommendationsRevisions_Stocks] FOREIGN KEY([Stock_Id])
REFERENCES [dbo].[ws_Stocks] ([Stock_Id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[reuters_RecommendationsRevisions] NOCHECK CONSTRAINT [FK_Reuters_RecommendationsRevisions_Stocks]
GO
ALTER TABLE [dbo].[ws_JobRuns]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobRuns_ws_Jobs] FOREIGN KEY([job_run_id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobRuns] NOCHECK CONSTRAINT [FK_ws_JobRuns_ws_Jobs]
GO
ALTER TABLE [dbo].[ws_Jobs]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_Jobs_ws_JobScheduler] FOREIGN KEY([scheduler_id])
REFERENCES [dbo].[ws_JobScheduler] ([scheduler_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_Jobs] NOCHECK CONSTRAINT [FK_ws_Jobs_ws_JobScheduler]
GO
ALTER TABLE [dbo].[ws_JobScheduler]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobScheduler_ws_JobSchedulerType] FOREIGN KEY([schedulertype_id])
REFERENCES [dbo].[wslu_JobSchedulerTypes] ([schedulertype_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobScheduler] NOCHECK CONSTRAINT [FK_ws_JobScheduler_ws_JobSchedulerType]
GO
ALTER TABLE [dbo].[ws_JobScheduler]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobScheduler_wslu_JobTypes] FOREIGN KEY([jobtype_id])
REFERENCES [dbo].[wslu_JobTypes] ([jobtype_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobScheduler] NOCHECK CONSTRAINT [FK_ws_JobScheduler_wslu_JobTypes]
GO
ALTER TABLE [dbo].[ws_JobScheduler_Daily]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobScheduler_Daily_ws_JobScheduler] FOREIGN KEY([scheduler_id])
REFERENCES [dbo].[ws_JobScheduler] ([scheduler_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobScheduler_Daily] NOCHECK CONSTRAINT [FK_ws_JobScheduler_Daily_ws_JobScheduler]
GO
ALTER TABLE [dbo].[ws_JobScheduler_Monthly]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobScheduler_Monthly_ws_JobScheduler] FOREIGN KEY([schedulder_id])
REFERENCES [dbo].[ws_JobScheduler] ([scheduler_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobScheduler_Monthly] NOCHECK CONSTRAINT [FK_ws_JobScheduler_Monthly_ws_JobScheduler]
GO
ALTER TABLE [dbo].[ws_JobScheduler_Weekly]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobScheduler_Weekly_ws_JobScheduler] FOREIGN KEY([scheduler_id])
REFERENCES [dbo].[ws_JobScheduler] ([scheduler_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobScheduler_Weekly] NOCHECK CONSTRAINT [FK_ws_JobScheduler_Weekly_ws_JobScheduler]
GO
ALTER TABLE [dbo].[ws_JobScheduler_Yearly]  WITH NOCHECK ADD  CONSTRAINT [FK_ws_JobScheduler_Yearly_ws_JobScheduler] FOREIGN KEY([scheduler_id])
REFERENCES [dbo].[ws_JobScheduler] ([scheduler_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_JobScheduler_Yearly] NOCHECK CONSTRAINT [FK_ws_JobScheduler_Yearly_ws_JobScheduler]
GO
ALTER TABLE [dbo].[ws_Logs]  WITH NOCHECK ADD  CONSTRAINT [FK_Logs_Jobs] FOREIGN KEY([job_run_Id])
REFERENCES [dbo].[ws_Jobs] ([Job_id])
NOT FOR REPLICATION 
GO
ALTER TABLE [dbo].[ws_Logs] NOCHECK CONSTRAINT [FK_Logs_Jobs]
GO
/****** Object:  StoredProcedure [dbo].[p_GetAllFieldsForJobScheduler]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[p_GetAllFieldsForJobScheduler]
@scheduler_id INT
AS
BEGIN
SELECT JS.scheduler_id,
       JS.name,
       JS.description,
       JS.jobtype_id,
       JS.start_date,
       JS.start_time,
       JS.end_date,
       JS.end_time,
       JS.schedulertype_id,
       JS.current_run_count,
       JS.max_run_count,
       JS.Status,
       ISNULL(JSD.schedule_daily_id,0) as schedule_daily_id ,
       ISNULL(JSD.recur_days,0) as recur_days_daily,
       JSD.IsWeekDay as IsWeekDay_daily,
	   ISNULL(JSW.scheduler_weekly_id,0) as scheduler_weekly_id,      
       ISNULL(JSW.weekly_freq,0) as weekly_freq,
       ISNULL( JSW.weekly_sunday,0) as weekly_sunday,
       ISNULL( JSW.weekly_monday,0) as weekly_monday,
       ISNULL(JSW.weekly_tuesday,0)as weekly_tuesday,
       ISNULL(JSW.weekly_wednesday,0) as weekly_wednesday,
       ISNULL( JSW.weekly_thursday,0) as weekly_thursday,
       ISNULL(JSW.weekly_friday,0) as weekly_friday,
       ISNULL(JSW.weekly_saturday,0) as weekly_saturday ,
	   JSM.scheduler_monthly_id,       
       JSM.monthly_nominal_day,
       JSM.monthly_nominal_month,
       JSM.monthly_day,
       JSM.monthly_week_of_day,
       JSM.monthly_freq,
       JSM.monthly_isweekday,
	   JSY.scheduler_yearly_id,       
       JSY.yearly_nominal_day,
       JSY.yearly_nominal_month,
	   JSY.yearly_day,
	   JSY.yearly_week_of_day,
	   JSY.yearly_month,
	   JSY.yearly_isweekday
FROM ws_JobScheduler JS
LEFT JOIN ws_JobScheduler_Daily JSD ON JS.scheduler_id = JSD.scheduler_id
LEFT JOIN  [dbo].[ws_JobScheduler_Weekly] JSW on JSW.scheduler_id =JS.scheduler_id
LEFT JOIN [dbo].[ws_JobScheduler_Monthly] JSM on JSM.schedulder_id = JS.scheduler_id
LEFT JOIN [dbo].[ws_JobScheduler_Yearly] JSY on JSY.scheduler_id = JS.scheduler_id
WHERE JS.scheduler_id = @scheduler_id
END

GO
/****** Object:  StoredProcedure [dbo].[p_GetJobScheduler]    Script Date: 5/18/2016 12:40:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[p_GetJobScheduler]
@scheduler_id INT,
@Name nvarchar(max)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT JS.scheduler_id as SchedulerId ,
       JS.name as Name,
       JS.description as Description,     
	   JT.jobtype_name as JobType,
       JS.start_date as StartDate,
       JS.start_time as StarTime,
       JS.end_date as EndDate,
       JS.end_time as EndTime ,       
	   JST.schedulartype_name as SchedularType ,
       JS.current_run_count as CurrentRunCount,
       JS.max_run_count as MaxRunCount
	FROM ws_JobScheduler JS
	INNER JOIN [dbo].[wslu_JobTypes] JT on JS.jobtype_id=JT.jobtype_id
	LEFT JOIN [dbo].[wslu_JobSchedulerTypes] JST on JS.schedulertype_id=JST.schedulertype_id
	WHERE @scheduler_id IN (JS.scheduler_id,0) 
	AND ((JS.name like '%'+@Name+'%' ) OR (@Name=''))
	AND JS.Status=1

END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=SALES (in millions), 2=Earnings (per share)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'reuters_Financials_SalesEstimates', @level2type=N'COLUMN',@level2name=N'Sale_Type'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'1=Daily,2=Monthly,3=Weekly,4=Yearly' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ws_JobScheduler', @level2type=N'COLUMN',@level2name=N'schedulertype_id'
GO
