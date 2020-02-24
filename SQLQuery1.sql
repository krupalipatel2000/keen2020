
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[CountryMaster]
(
	[ID]           [int] IDENTITY(1, 1) NOT NULL,
	[Name]         [nvarchar](50) NULL,
	[CountryCode]  [varchar](5) NULL,
	CONSTRAINT [PK_CountryMaster] PRIMARY KEY CLUSTERED([ID] ASC)WITH (
	    PAD_INDEX = OFF,
	    STATISTICS_NORECOMPUTE = OFF,
	    IGNORE_DUP_KEY = OFF,
	    ALLOW_ROW_LOCKS = ON,
	    ALLOW_PAGE_LOCKS = ON
	) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

SET IDENTITY_INSERT [dbo].[CountryMaster] ON
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    1,
    N'Afghanistan',
    N'AF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    2,
    N'Albania',
    N'AL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    3,
    N'Algeria',
    N'DZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    4,
    N'American Samoa',
    N'AS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    5,
    N'Andorra',
    N'AD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    6,
    N'Angola',
    N'AO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    7,
    N'Anguilla',
    N'AI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    8,
    N'Antarctica',
    N'AQ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    9,
    N'Antigua And Barbuda',
    N'AG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    10,
    N'Argentina',
    N'AR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    11,
    N'Armenia',
    N'AM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    12,
    N'Aruba',
    N'AW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    13,
    N'Australia',
    N'AU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    14,
    N'Austria',
    N'AT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    15,
    N'Azerbaijan',
    N'AZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    16,
    N'Bahamas The',
    N'BS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    17,
    N'Bahrain',
    N'BH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    18,
    N'Bangladesh',
    N'BD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    19,
    N'Barbados',
    N'BB'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    20,
    N'Belarus',
    N'BY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    21,
    N'Belgium',
    N'BE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    22,
    N'Belize',
    N'BZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    23,
    N'Benin',
    N'BJ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    24,
    N'Bermuda',
    N'BM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    25,
    N'Bhutan',
    N'BT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    26,
    N'Bolivia',
    N'BO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    27,
    N'Bosnia and Herzegovina',
    N'BA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    28,
    N'Botswana',
    N'BW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    29,
    N'Bouvet Island',
    N'BV'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    30,
    N'Brazil',
    N'BR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    31,
    N'British Indian Ocean Territory',
    N'IO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    32,
    N'Brunei',
    N'BN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    33,
    N'Bulgaria',
    N'BG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    34,
    N'Burkina Faso',
    N'BF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    35,
    N'Burundi',
    N'BI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    36,
    N'Cambodia',
    N'KH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    37,
    N'Cameroon',
    N'CM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    38,
    N'Canada',
    N'CA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    39,
    N'Cape Verde',
    N'CV'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    40,
    N'Cayman Islands',
    N'KY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    41,
    N'Central African Republic',
    N'CF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    42,
    N'Chad',
    N'TD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    43,
    N'Chile',
    N'CL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    44,
    N'China',
    N'CN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    45,
    N'Christmas Island',
    N'CX'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    46,
    N'Cocos (Keeling) Islands',
    N'CC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    47,
    N'Colombia',
    N'CO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    48,
    N'Comoros',
    N'KM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    49,
    N'Congo',
    N'CG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    50,
    N'Congo The Democratic Republic Of The',
    N'CD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    51,
    N'Cook Islands',
    N'CK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    52,
    N'Costa Rica',
    N'CR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    53,
    N'Cote D''Ivoire (Ivory Coast)',
    N'CI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    54,
    N'Croatia (Hrvatska)',
    N'HR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    55,
    N'Cuba',
    N'CU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    56,
    N'Cyprus',
    N'CY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    57,
    N'Czech Republic',
    N'CZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    58,
    N'Denmark',
    N'DK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    59,
    N'Djibouti',
    N'DJ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    60,
    N'Dominica',
    N'DM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    61,
    N'Dominican Republic',
    N'DO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    62,
    N'East Timor',
    N'TP'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    63,
    N'Ecuador',
    N'EC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    64,
    N'Egypt',
    N'EG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    65,
    N'El Salvador',
    N'SV'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    66,
    N'Equatorial Guinea',
    N'GQ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    67,
    N'Eritrea',
    N'ER'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    68,
    N'Estonia',
    N'EE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    69,
    N'Ethiopia',
    N'ET'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    70,
    N'External Territories of Australia',
    N'XA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    71,
    N'Falkland Islands',
    N'FK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    72,
    N'Faroe Islands',
    N'FO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    73,
    N'Fiji Islands',
    N'FJ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    74,
    N'Finland',
    N'FI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    75,
    N'France',
    N'FR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    76,
    N'French Guiana',
    N'GF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    77,
    N'French Polynesia',
    N'PF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    78,
    N'French Southern Territories',
    N'TF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    79,
    N'Gabon',
    N'GA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    80,
    N'Gambia The',
    N'GM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    81,
    N'Georgia',
    N'GE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    82,
    N'Germany',
    N'DE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    83,
    N'Ghana',
    N'GH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    84,
    N'Gibraltar',
    N'GI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    85,
    N'Greece',
    N'GR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    86,
    N'Greenland',
    N'GL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    87,
    N'Grenada',
    N'GD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    88,
    N'Guadeloupe',
    N'GP'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    89,
    N'Guam',
    N'GU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    90,
    N'Guatemala',
    N'GT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    91,
    N'Guernsey and Alderney',
    N'XU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    92,
    N'Guinea',
    N'GN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    93,
    N'Guinea-Bissau',
    N'GW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    94,
    N'Guyana',
    N'GY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    95,
    N'Haiti',
    N'HT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    96,
    N'Heard and McDonald Islands',
    N'HM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    97,
    N'Honduras',
    N'HN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    98,
    N'Hong Kong S.A.R.',
    N'HK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    99,
    N'Hungary',
    N'HU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    100,
    N'Iceland',
    N'IS'
  )
GO

PRINT 'Processed 100 total records'
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    101,
    N'India',
    N'IN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    102,
    N'Indonesia',
    N'ID'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    103,
    N'Iran',
    N'IR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    104,
    N'Iraq',
    N'IQ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    105,
    N'Ireland',
    N'IE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    106,
    N'Israel',
    N'IL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    107,
    N'Italy',
    N'IT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    108,
    N'Jamaica',
    N'JM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    109,
    N'Japan',
    N'JP'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    110,
    N'Jersey',
    N'XJ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    111,
    N'Jordan',
    N'JO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    112,
    N'Kazakhstan',
    N'KZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    113,
    N'Kenya',
    N'KE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    114,
    N'Kiribati',
    N'KI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    115,
    N'Korea North',
    N'KP'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    116,
    N'Korea South',
    N'KR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    117,
    N'Kuwait',
    N'KW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    118,
    N'Kyrgyzstan',
    N'KG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    119,
    N'Laos',
    N'LA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    120,
    N'Latvia',
    N'LV'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    121,
    N'Lebanon',
    N'LB'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    122,
    N'Lesotho',
    N'LS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    123,
    N'Liberia',
    N'LR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    124,
    N'Libya',
    N'LY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    125,
    N'Liechtenstein',
    N'LI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    126,
    N'Lithuania',
    N'LT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    127,
    N'Luxembourg',
    N'LU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    128,
    N'Macau S.A.R.',
    N'MO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    129,
    N'Macedonia',
    N'MK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    130,
    N'Madagascar',
    N'MG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    131,
    N'Malawi',
    N'MW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    132,
    N'Malaysia',
    N'MY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    133,
    N'Maldives',
    N'MV'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    134,
    N'Mali',
    N'ML'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    135,
    N'Malta',
    N'MT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    136,
    N'Man (Isle of)',
    N'XM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    137,
    N'Marshall Islands',
    N'MH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    138,
    N'Martinique',
    N'MQ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    139,
    N'Mauritania',
    N'MR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    140,
    N'Mauritius',
    N'MU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    141,
    N'Mayotte',
    N'YT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    142,
    N'Mexico',
    N'MX'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    143,
    N'Micronesia',
    N'FM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    144,
    N'Moldova',
    N'MD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    145,
    N'Monaco',
    N'MC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    146,
    N'Mongolia',
    N'MN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    147,
    N'Montserrat',
    N'MS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    148,
    N'Morocco',
    N'MA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    149,
    N'Mozambique',
    N'MZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    150,
    N'Myanmar',
    N'MM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    151,
    N'Namibia',
    N'NA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    152,
    N'Nauru',
    N'NR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    153,
    N'Nepal',
    N'NP'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    154,
    N'Netherlands Antilles',
    N'AN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    155,
    N'Netherlands The',
    N'NL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    156,
    N'New Caledonia',
    N'NC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    157,
    N'New Zealand',
    N'NZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    158,
    N'Nicaragua',
    N'NI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    159,
    N'Niger',
    N'NE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    160,
    N'Nigeria',
    N'NG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    161,
    N'Niue',
    N'NU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    162,
    N'Norfolk Island',
    N'NF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    163,
    N'Northern Mariana Islands',
    N'MP'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    164,
    N'Norway',
    N'NO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    165,
    N'Oman',
    N'OM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    166,
    N'Pakistan',
    N'PK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    167,
    N'Palau',
    N'PW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    168,
    N'Palestinian Territory Occupied',
    N'PS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    169,
    N'Panama',
    N'PA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    170,
    N'Papua new Guinea',
    N'PG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    171,
    N'Paraguay',
    N'PY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    172,
    N'Peru',
    N'PE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    173,
    N'Philippines',
    N'PH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    174,
    N'Pitcairn Island',
    N'PN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    175,
    N'Poland',
    N'PL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    176,
    N'Portugal',
    N'PT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    177,
    N'Puerto Rico',
    N'PR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    178,
    N'Qatar',
    N'QA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    179,
    N'Reunion',
    N'RE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    180,
    N'Romania',
    N'RO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    181,
    N'Russia',
    N'RU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    182,
    N'Rwanda',
    N'RW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    183,
    N'Saint Helena',
    N'SH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    184,
    N'Saint Kitts And Nevis',
    N'KN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    185,
    N'Saint Lucia',
    N'LC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    186,
    N'Saint Pierre and Miquelon',
    N'PM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    187,
    N'Saint Vincent And The Grenadines',
    N'VC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    188,
    N'Samoa',
    N'WS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    189,
    N'San Marino',
    N'SM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    190,
    N'Sao Tome and Principe',
    N'ST'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    191,
    N'Saudi Arabia',
    N'SA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    192,
    N'Senegal',
    N'SN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    193,
    N'Serbia',
    N'RS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    194,
    N'Seychelles',
    N'SC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    195,
    N'Sierra Leone',
    N'SL'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    196,
    N'Singapore',
    N'SG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    197,
    N'Slovakia',
    N'SK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    198,
    N'Slovenia',
    N'SI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    199,
    N'Smaller Territories of the UK',
    N'XG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    200,
    N'Solomon Islands',
    N'SB'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    201,
    N'Somalia',
    N'SO'
  )
GO

PRINT 'Processed 200 total records'
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    202,
    N'South Africa',
    N'ZA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    203,
    N'South Georgia',
    N'GS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    204,
    N'South Sudan',
    N'SS'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    205,
    N'Spain',
    N'ES'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    206,
    N'Sri Lanka',
    N'LK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    207,
    N'Sudan',
    N'SD'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    208,
    N'Suriname',
    N'SR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    209,
    N'Svalbard And Jan Mayen Islands',
    N'SJ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    210,
    N'Swaziland',
    N'SZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    211,
    N'Sweden',
    N'SE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    212,
    N'Switzerland',
    N'CH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    213,
    N'Syria',
    N'SY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    214,
    N'Taiwan',
    N'TW'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    215,
    N'Tajikistan',
    N'TJ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    216,
    N'Tanzania',
    N'TZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    217,
    N'Thailand',
    N'TH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    218,
    N'Togo',
    N'TG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    219,
    N'Tokelau',
    N'TK'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    220,
    N'Tonga',
    N'TO'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    221,
    N'Trinidad And Tobago',
    N'TT'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    222,
    N'Tunisia',
    N'TN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    223,
    N'Turkey',
    N'TR'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    224,
    N'Turkmenistan',
    N'TM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    225,
    N'Turks And Caicos Islands',
    N'TC'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    226,
    N'Tuvalu',
    N'TV'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    227,
    N'Uganda',
    N'UG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    228,
    N'Ukraine',
    N'UA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    229,
    N'United Arab Emirates',
    N'AE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    230,
    N'United Kingdom',
    N'GB'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    231,
    N'United States',
    N'US'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    232,
    N'United States Minor Outlying Islands',
    N'UM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    233,
    N'Uruguay',
    N'UY'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    234,
    N'Uzbekistan',
    N'UZ'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    235,
    N'Vanuatu',
    N'VU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    236,
    N'Vatican City State (Holy See)',
    N'VA'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    237,
    N'Venezuela',
    N'VE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    238,
    N'Vietnam',
    N'VN'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    239,
    N'Virgin Islands (British)',
    N'VG'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    240,
    N'Virgin Islands (US)',
    N'VI'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    241,
    N'Wallis And Futuna Islands',
    N'WF'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    242,
    N'Western Sahara',
    N'EH'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    243,
    N'Yemen',
    N'YE'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    244,
    N'Yugoslavia',
    N'YU'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    245,
    N'Zambia',
    N'ZM'
  )
INSERT [dbo].[CountryMaster]
  (
    [ID],
    [Name],
    [CountryCode]
  )
VALUES
  (
    246,
    N'Zimbabwe',
    N'ZW'
  )
SET IDENTITY_INSERT [dbo].[CountryMaster] OFF
