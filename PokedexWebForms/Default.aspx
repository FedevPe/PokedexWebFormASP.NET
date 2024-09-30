<%@ Page Title="Loading..." Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PokedexWebForms.Default" %>
<!DOCTYPE html>

<html lang="es">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title><%: Page.Title %></title>

    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/modernizr") %>
    </asp:PlaceHolder>

    <webopt:bundlereference runat="server" path="~/Content/css" />
    <link href="Resources/FaviconPokeball.png" rel="shortcut icon" type="image/x-icon" />
    <script type="text/javascript">
        document.addEventListener("DOMContentLoaded", function () {
            var elemento = document.getElementById("pokeballAnim");

            
            setTimeout(function () {
                elemento.classList.add("bounce-in-top");
            });
            setTimeout(function () {
                elemento.classList.add("pulsate-fwd");
            }, 1500); 
            setTimeout(function () {
                elemento.classList.replace("pulsate-fwd","rotate-out-center");
            }, 5000);
        });

        setTimeout(function () {
            window.location.href = 'ListPokemons.aspx';
        }, 4000);
    </script>

</head>
<body>       
    <div class="pokeball" id="pokeballAnim">
        <div class="pokeball-button"></div>
        <div class="shine"></div>
    </div>

    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-color: #f0f0f0;
        }

        .pokeball {
            width: 200px;
            height: 200px;
            background-color: #fff;
            border-radius: 50%;
            position: relative;
            overflow: hidden;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.3);
        }

        .pokeball::before {
            content: "";
            position: absolute;
            background-color: #ff1a1a;
            width: 100%;
            height: 50%;
            top: 0;
        }

        .pokeball::after {
            content: "";
            position: absolute;
            top: calc(50% - 5px);
            left: 0;
            width: 100%;
            height: 10px;
            background-color: #000;
        }

        .pokeball-button {
            width: 60px;
            height: 60px;
            background-color: #fff;
            border: 10px solid #000;
            border-radius: 50%;
            position: absolute;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            z-index: 10;
            box-shadow: 0 0 0 5px #fff;
        }

        .pokeball-button::before {
            content: "";
            position: absolute;
            width: 40px;
            height: 40px;
            background-color: #fff;
            border: 4px solid #7f7f7f;
            border-radius: 50%;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
        }

        .shine {
            position: absolute;
            width: 30px;
            height: 45px;
            background-color: rgba(255, 255, 255, 0.5);
            border-radius: 50%;
            transform: rotate(45deg);
            top: 25px;
            left: 25px;
        }
        .bounce-in-top{
            -webkit-animation:bounce-in-top 1s both;
            animation:bounce-in-top 1s both;
        }
        .rotate-out-center{-webkit-animation:rotate-out-center .6s cubic-bezier(.55,.085,.68,.53) both;animation:rotate-out-center .6s cubic-bezier(.55,.085,.68,.53) both}
        .pulsate-fwd{
            -webkit-animation:pulsate-fwd 0.5s ease-in-out infinite both;
            animation:pulsate-fwd 0.5s ease-in-out infinite both;
        }
        
@-webkit-keyframes bounce-in-top{0%{-webkit-transform:translateY(-500px);transform:translateY(-500px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in;opacity:0}38%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out;opacity:1}55%{-webkit-transform:translateY(-65px);transform:translateY(-65px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in}72%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out}81%{-webkit-transform:translateY(-28px);transform:translateY(-28px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in}90%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out}95%{-webkit-transform:translateY(-8px);transform:translateY(-8px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in}100%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out}}@keyframes bounce-in-top{0%{-webkit-transform:translateY(-500px);transform:translateY(-500px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in;opacity:0}38%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out;opacity:1}55%{-webkit-transform:translateY(-65px);transform:translateY(-65px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in}72%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out}81%{-webkit-transform:translateY(-28px);transform:translateY(-28px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in}90%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out}95%{-webkit-transform:translateY(-8px);transform:translateY(-8px);-webkit-animation-timing-function:ease-in;animation-timing-function:ease-in}100%{-webkit-transform:translateY(0);transform:translateY(0);-webkit-animation-timing-function:ease-out;animation-timing-function:ease-out}}
@-webkit-keyframes pulsate-fwd{0%{-webkit-transform:scale(1);transform:scale(1)}50%{-webkit-transform:scale(1.1);transform:scale(1.1)}100%{-webkit-transform:scale(1);transform:scale(1)}}@keyframes pulsate-fwd{0%{-webkit-transform:scale(1);transform:scale(1)}50%{-webkit-transform:scale(1.1);transform:scale(1.1)}100%{-webkit-transform:scale(1);transform:scale(1)}}
@-webkit-keyframes rotate-out-center{0%{-webkit-transform:rotate(0);transform:rotate(0);opacity:1}100%{-webkit-transform:rotate(-360deg);transform:rotate(-360deg);opacity:0}}@keyframes rotate-out-center{0%{-webkit-transform:rotate(0);transform:rotate(0);opacity:1}100%{-webkit-transform:rotate(-360deg);transform:rotate(-360deg);opacity:0}}

    </style>

</body>
</html>







