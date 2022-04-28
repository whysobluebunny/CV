<!doctype html>
<%
   String textBox = (String) session.getAttribute("command");
     if(textBox == null){
      textBox = " ";
   }
   String result = (String) session.getAttribute("result");
   if(result == null){
       result = " ";
   }
   
   %>
<html lang="en">
   <head>
      <title>CNT 4714 – Spring 2022 – Project Four</title>
      <style type="text/css">
         <!--
            body, html {
             height: 100%;
            }
            
            * {
             box-sizing: border-box;
            }
            
            .bg-image {
             /* The image used */
             background-image: url("https://images.wallpapersden.com/image/download/grey-background-and-colorful-circle_a2toZ2uUmZqaraWkpJRobWllrWdma2U.jpg");
            
             /* Add the blur effect */
             filter: blur(8px);
             -webkit-filter: blur(8px);
            
             /* Full height */
             height: 100%;
            
             /* Center and scale the image nicely */
             background-position: center;
             background-repeat: no-repeat;
             background-size: cover;
            }
            
            .bg-text {
             background-color: rgb(0,0,0); /* Fallback color */
             background-color: rgba(0,0,0, 0.4); /* Black w/opacity/see-through */
             color: white;
             font-weight: bold;
             border: 3px solid #f1f1f1;
             position: absolute;
             top: 50%;
             left: 50%;
             transform: translate(-50%, -50%);
             z-index: 2;
             width: 80%;
             padding: 20px;
             text-align: center;
            }
                    body { 
                       background-color: #9ea19a;
                   }
                    h1 { 
                       color:white;  
                       text-align:center;
                   }
                    h4{
                       color:white; 
                       text-align:center;
                   }
                    p{
                       color:white; 
                       text-align:center;
                    }
                    button {
                       background-color: white; 
                       font-weight:bold;
                   }
                    table{ 
                       margin-left: auto; 
                       margin-right: auto;
                    }
                   row{
                       text-align:center;
                   }
                    div{
                       text-align:center;
                   }
                    textarea{ 
                       background-color: white;
                       color:black;
                        }
             th{
                       background-color: gray;
                   }
                    td{
                       background-color: white;
                       color:black;
                   }
            
                   -->
      </style>
   </head>
   <body>
      <input type=hidden name=”user” value=”client”>
      <div id="backgr" class="bg-image"></div>
      <div class="bg-text">
         <h1>Project Four: Developing A Three-Tier Distributed Web-Based Application</h1>
         <h4>Developer: Kamilla Idelguzhina</h4>
         <p>You are connected to the Project 4 Enterprise System as a client-level user.</p>
         <p>Please enter any valid SQL query or update command in the box below.</p>
         <br>
         <hr>
         <div class="container-fluid ">
            <row>
               <form action = "/project4/SQLQueryClientServlet" method = "post" class="text-center">
                  <div class="form-group row">
                     <div>
                        <textarea name="command" class="form-control" id="command" rows="8" cols="50"><%= textBox %></textarea>
                     </div>
                  </div>
                  <button type="submit">Execute Command</button>
                  <button onclick="document.getElementById('command').value = ''" >Reset Form</button>
               </form>
            </row>
         </div>
         <br>
         <p>All exectution results will appear below this line.</p>
         <hr>
         <p>Database Results:</p>
         <div>
            <%= result %>
         </div>
      </div>
      </div>
	  
<script src="https://cdnjs.cloudflare.com/ajax/libs/three.js/r121/three.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/vanta@latest/dist/vanta.globe.min.js"></script>
<script>
VANTA.GLOBE({
  el: "#backgr",
  mouseControls: true,
  touchControls: true,
  gyroControls: false,
  minHeight: 200.00,
  minWidth: 200.00,
  scale: 1.00,
  scaleMobile: 1.00
})
</script>
   </body>
</html>