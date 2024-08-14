using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace generatePDF.HTML
{
    public partial class FirstPage
    {
        public const string HtmlContent = @"<!DOCTYPE html>
<html lang=""en"">
<head>
    <meta charset=""UTF-8"" />
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"" />
    <link href=""https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css"" rel=""stylesheet"">
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
            border: 1px #D3D3D3 solid;
            border-radius: 5px;
            background: white;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            position: relative;
        }

        .content {
            margin-top: 0mm; /* Adjust as needed to make space for the header */
            margin-bottom: 0mm; /* Adjust as needed to make space for the footer */
        }

        .person-info {
            display: flex;
            justify-content: space-between;
            border: 1px solid #dee2e6;
            border-radius: 5px;
            padding: 10px;
            margin-bottom: 10px;
        }

            .person-info .left,
            .person-info .right {
                display: flex;
                align-items: center;
            }

                .person-info .left img {
                    border-radius: 50%;
                    margin-right: 10px;
                }

                .person-info .left .name {
                    font-size: 16px;
                    font-weight: bold;
                }

            .person-info .right {
                text-align: right;
            }

                .person-info .right .status {
                    font-size: 16px;
                    font-weight: bold;
                    color: red;
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

        .profile {
            position: relative;
            display: flex;
            align-items: center;
            background: #F6F5F5;
            padding: 15px;
            border-radius: 15px;
            margin-bottom: 30px;
            height: 50mm;
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

        .cc {
            position: fixed;
            left: 40mm;
            top: 9mm;
        }

        .dd {
            position: fixed;
            left: 170mm;
            top: 10mm;
            border-radius: 15px;
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .pep-status-container {
            display: flex;
            flex-direction: column;
            align-items: center;
        }

        .pep-status {
            display: inline-block;
            justify-items: center;
            align-items: center;
            width: 130px;
            height: 15mm;
            background-color: [color-statu];
            color: white;
            border-radius: 5px;
            font-weight: bold;
            text-align: center;
            line-height: 15mm; /* Adjust to vertically center text */
        }
    </style>
</head>
<body>
    <div id=""content"">
        <div class=""page"">
            <div class=""content"">
                <div class=""profile"" style=""display: flex; align-items: center;"">
                    <img src=""[image.url]"" alt=""Profile Image"" style=""margin-right: 10px;"">
                    <div class=""cc"">
                        <h4>First Name: [@first-name]</h4>
                        <h4>Last Name: [@last-name]</h4>
                        <h5>Avg. Match Rate: [match-rate]</h5>
                    </div>
                    <div class=""dd"" style=""margin-left: auto;"">
                        <div class=""pep-status-container"">
                            <h5>PEP Status:</h5>
                            <h5 class=""pep-status"">[pep-statu]</h5>
                        </div>
                    </div>
                </div>
                <table class=""table"">
                    <thead>
                        <tr>
                            <th class=""matching-font"" scope=""col"">#</th>
                            <th class=""matching-font"" scope=""col"">Fullname</th>
                            <th class=""matching-font"" scope=""col"">Type</th>
                            <th class=""matching-font"" scope=""col"">Occupations</th>
                            <th class=""matching-font"" scope=""col"">Description</th>
                        </tr>
                    </thead>
                    <tbody>
                        [@PERSONS.DATA]
                    </tbody>
                </table>
            </div>
        </div>
    </div>
</body>
</html>";
    }
}
