using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatePDF.HTML
{
    public partial class SecondPage
    {
        public const string HtmlPerson = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <link href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" rel=""stylesheet"">
    <link href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css"" rel=""stylesheet"">

    <title>Dynamic PDF</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: white;
        }

        .page {
            width: 100%;
            position: relative;
        }

        .content {
            margin-top: 0mm; /* Adjust as needed to make space for the header */
            margin-bottom: 0mm; /* Adjust as needed to make space for the footer */
        }

        .page-break {
            page-break-before: always;
        }

        .table {
            width: 100%;
            margin-bottom: 1rem;
            color: #212529;
            border-collapse: collapse;
        }

            .table th,
            .table td {
                padding: 0.75rem;
                vertical-align: top;
                border-top: 1px solid #dee2e6;
            }

            .table thead th {
                vertical-align: bottom;
                border-bottom: 2px solid #dee2e6;
            }

            .table tbody + tbody {
                border-top: 2px solid #dee2e6;
            }

            .table .table {
                background-color: #fff;
            }

        .table-sm th,
        .table-sm td {
            padding: 0.3rem;
        }

        .table-bordered {
            border: 1px solid #dee2e6;
        }

            .table-bordered th,
            .table-bordered td {
                border: 1px solid #dee2e6;
            }

            .table-bordered thead th,
            .table-bordered thead td {
                border-bottom-width: 2px;
            }

        .table-borderless th,
        .table-borderless td,
        .table-borderless thead th,
        .table-borderless tbody + tbody {
            border: 0;
        }

        .table-striped tbody tr:nth-of-type(odd) {
            background-color: rgba(0, 0, 0, 0.05);
        }

        .table-hover tbody tr:hover {
            background-color: rgba(0, 0, 0, 0.075);
        }

        .table-primary,
        .table-primary > th,
        .table-primary > td {
            background-color: #b8daff;
        }

        .table-secondary,
        .table-secondary > th,
        .table-secondary > td {
            background-color: #d6d8db;
        }

        .table-success,
        .table-success > th,
        .table-success > td {
            background-color: #c3e6cb;
        }

        .table-info,
        .table-info > th,
        .table-info > td {
            background-color: #bee5eb;
        }

        .table-warning,
        .table-warning > th,
        .table-warning > td {
            background-color: #ffeeba;
        }

        .table-danger,
        .table-danger > th,
        .table-danger > td {
            background-color: #f5c6cb;
        }

        .table-light,
        .table-light > th,
        .table-light > td {
            background-color: #fdfdfe;
        }

        .table-dark,
        .table-dark > th,
        .table-dark > td {
            background-color: #c6c8ca;
        }

        .table-active,
        .table-active > th,
        .table-active > td {
            background-color: rgba(0, 0, 0, 0.075);
        }

        .table-hover .table-primary:hover {
            background-color: #9fcdff;
        }

        .table-hover .table-secondary:hover {
            background-color: #c8cbcf;
        }

        .table-hover .table-success:hover {
            background-color: #b1dfbb;
        }

        .table-hover .table-info:hover {
            background-color: #abdde5;
        }

        .table-hover .table-warning:hover {
            background-color: #ffe8a1;
        }

        .table-hover .table-danger:hover {
            background-color: #f1b0b7;
        }

        .table-hover .table-light:hover {
            background-color: #ececf6;
        }

        .table-hover .table-dark:hover {
            background-color: #b9bbbe;
        }

        .table-hover .table-active:hover {
            background-color: rgba(0, 0, 0, 0.075);
        }

        .table-hover .table-secondary:hover > td,
        .table-hover .table-secondary:hover > th {
            background-color: #c8cbcf;
        }

        .table-hover .table-light:hover > td,
        .table-hover .table-light:hover > th {
            background-color: #ececf6;
        }

        .matching-font {
            font-style: normal;
            font-size: 13.00px;
            font-weight: 400;
            font-family: Helvetica, Arial;
            letter-spacing: 3px;
        }

        img {
            max-height: 150px;
            max-width: 100%;
        }

        .profile img {
            border-radius: 10%;
        }

        .contact-details p {
            margin: 0;
        }

        .contact-details i {
            margin-right: 5px;
        }

        .custom-content {
            margin-top: 0mm; /* Adjust as needed to make space for the header */
            margin-bottom: 0mm; /* Adjust as needed to make space for the footer */
        }

        .row {
            display: flex;
            flex-wrap: wrap;
            margin-right: -15px;
            margin-left: -15px;
        }

        .col-3 {
            position: relative;
            padding-right: 15px;
            padding-left: 15px;
            flex: 0 0 25%;
            max-width: 40%;
        }

        .cc {
            position: relative;
            left: 35mm;
            top: -30mm;
            width: 100mm;
            height: 30mm;
        }

        .dd {
            position: relative;
            left: 160mm;
            top: -62mm;
            height: 30mm;
        }

        .profile {
            align-items: center;
            background: #F6F5F5;
            padding: 15px;
            border-radius: 15px;
            margin-bottom: 30px;
            height: 50mm;
        }
    </style>
</head>
<body>
    [pleaceholder-content]
</body>
</html>
";
    }
}
