using System;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Windows.Forms;

namespace New_Packman
{
    public partial class Form1 : Form
    {
        //Start
        string startMove = "left";
        string startgame = "No";
        int startplayerAngle1;
        int startplayerAngle2;
        int startCount = 0;
        int waitCount = 0;
        Rectangle startplayer = new Rectangle(560, 233, 35, 35);

        //Graphics
        Pen wordPen = new Pen(Color.FromArgb(53, 40, 220), 3);
        Pen edgePen = new Pen(Color.FromArgb(35, 35, 202), 3);

        //Player
        SolidBrush yellowBrush = new SolidBrush(Color.FromArgb(253, 229, 5));
        Rectangle player = new Rectangle(273, 447, 16, 16);
        Rectangle life1 = new Rectangle(530, 470, 16, 16);
        Rectangle life2 = new Rectangle(510, 470, 16, 16);
        Rectangle life3 = new Rectangle(490, 470, 16, 16);
        int life = 3;
        int gameclearCount = 0;
        int point = 0;
        int eatEnemiesPoint = 0;
        int powerupCount = 0;
        int playerSpeed = 1;
        int playerAngle1 = 0;
        int playerAngle2 = 360;
        int opencloseCount;
        int gameoverCount;
        string situation = "start";
        string lifecheck = "No";
        string playerDirection;
        string playerLocation;
        string powerup = "false";
        bool up = false;
        bool down = false;
        bool right = false;
        bool left = false;
        bool space = false;

        //Enemies
        SolidBrush transparentBrush = new SolidBrush(Color.Transparent);
        int enemyCount;
        int enemy1X = 93;
        int enemy1Y = 57;
        int enemy2X = 233;
        int enemy2Y = 77;
        int enemy3X = 313;
        int enemy3Y = 77;
        int enemy4X = 453;
        int enemy4Y = 57;
        int enemy5X = 63;
        int enemy5Y = 242;
        int enemy6X = 483;
        int enemy6Y = 242;
        int enemy7X = 113;
        int enemy7Y = 367;
        int enemy8X = 433;
        int enemy8Y = 367;
        int enemySpeed = 1;
        string enemy1Location = "T5";
        string enemy2Location = "T21";
        string enemy3Location = "T27";
        string enemy4Location = "T39";
        string enemy5Location = "M15";
        string enemy6Location = "M17";
        string enemy7Location = "B19";
        string enemy8Location = "B28";
        string enemy1Direction;
        string enemy2Direction;
        string enemy3Direction;
        string enemy4Direction;
        string enemy5Direction;
        string enemy6Direction;
        string enemy7Direction;
        string enemy8Direction;
        Random enemy1RandGen = new Random();
        Random enemy2RandGen = new Random();
        Random enemy3RandGen = new Random();
        Random enemy4RandGen = new Random();
        Random enemy7RandGen = new Random();
        Random enemy8RandGen = new Random();
        int enemy1RandNum;
        int enemy2RandNum;
        int enemy3RandNum;
        int enemy4RandNum;
        int enemy7RandNum;
        int enemy8RandNum;
        int enemy1Dire2;
        int enemy1Dire3;
        int enemy2Dire2;
        int enemy2Dire3;
        int enemy3Dire2;
        int enemy3Dire3;
        int enemy4Dire2;
        int enemy4Dire3;
        int enemy7Dire2;
        int enemy7Dire3;
        int enemy7Dire4;
        int enemy8Dire2;
        int enemy8Dire3;
        int enemy8Dire4;
        string enemyWeakColor = "blue";

        //Sound
        SoundPlayer pointSound = new SoundPlayer(Properties.Resources.pacman_chomp);
        SoundPlayer bigSound = new SoundPlayer(Properties.Resources.pacman_extrapac);
        SoundPlayer eatEnemiesSound = new SoundPlayer(Properties.Resources.pacman_eatghost);
        SoundPlayer gameoverSound = new SoundPlayer(Properties.Resources.pacman_death);
        SoundPlayer clearSound = new SoundPlayer(Properties.Resources.pacman_intermission);
        SoundPlayer beginningSound = new SoundPlayer(Properties.Resources.pacman_beginning);

        //Point
        SolidBrush pointBrush = new SolidBrush(Color.FromArgb(255, 207, 185));
        SolidBrush bigpointBrush = new SolidBrush(Color.FromArgb(255, 238, 231));
        Rectangle smallPoint1 = new Rectangle(19, 23, 5, 5);
        Rectangle smallPoint2 = new Rectangle(39, 23, 5, 5);
        Rectangle smallPoint3 = new Rectangle(59, 23, 5, 5);
        Rectangle smallPoint4 = new Rectangle(79, 23, 5, 5);
        Rectangle smallPoint5 = new Rectangle(99, 23, 5, 5);
        Rectangle smallPoint6 = new Rectangle(119, 23, 5, 5);
        Rectangle smallPoint7 = new Rectangle(139, 23, 5, 5);
        Rectangle smallPoint8 = new Rectangle(19, 43, 5, 5);
        Rectangle smallPoint9 = new Rectangle(19, 63, 5, 5);
        Rectangle smallPoint10 = new Rectangle(19, 83, 5, 5);
        Rectangle smallPoint11 = new Rectangle(19, 103, 5, 5);
        Rectangle smallPoint12 = new Rectangle(19, 123, 5, 5);
        Rectangle smallPoint13 = new Rectangle(19, 143, 5, 5);
        Rectangle smallPoint14 = new Rectangle(19, 163, 5, 5);
        Rectangle smallPoint15 = new Rectangle(19, 183, 5, 5);
        Rectangle smallPoint16 = new Rectangle(19, 203, 5, 5);
        Rectangle smallPoint17 = new Rectangle(139, 43, 5, 5);
        Rectangle smallPoint18 = new Rectangle(139, 63, 5, 5);
        Rectangle smallPoint19 = new Rectangle(139, 83, 5, 5);
        Rectangle smallPoint20 = new Rectangle(139, 103, 5, 5);
        Rectangle smallPoint21 = new Rectangle(139, 123, 5, 5);
        Rectangle smallPoint22 = new Rectangle(139, 143, 5, 5);
        Rectangle smallPoint23 = new Rectangle(139, 163, 5, 5);
        Rectangle smallPoint24 = new Rectangle(139, 183, 5, 5);
        Rectangle smallPoint25 = new Rectangle(139, 203, 5, 5);
        Rectangle smallPoint26 = new Rectangle(99, 43, 5, 5);
        Rectangle smallPoint27 = new Rectangle(39, 63, 5, 5);
        Rectangle smallPoint28 = new Rectangle(59, 63, 5, 5);
        Rectangle smallPoint29 = new Rectangle(79, 63, 5, 5);
        Rectangle smallPoint30 = new Rectangle(39, 103, 5, 5);
        Rectangle smallPoint31 = new Rectangle(59, 103, 5, 5);
        Rectangle smallPoint32 = new Rectangle(59, 123, 5, 5);
        Rectangle smallPoint33 = new Rectangle(59, 143, 5, 5);
        Rectangle smallPoint34 = new Rectangle(59, 163, 5, 5);
        Rectangle smallPoint35 = new Rectangle(79, 163, 5, 5);
        Rectangle smallPoint36 = new Rectangle(99, 163, 5, 5);
        Rectangle smallPoint37 = new Rectangle(99, 103, 5, 5);
        Rectangle smallPoint38 = new Rectangle(119, 103, 5, 5);
        Rectangle smallPoint39 = new Rectangle(99, 123, 5, 5);
        Rectangle smallPoint40 = new Rectangle(99, 143, 5, 5);
        Rectangle smallPoint41 = new Rectangle(99, 163, 5, 5);
        Rectangle smallPoint42 = new Rectangle(99, 183, 5, 5);
        Rectangle smallPoint43 = new Rectangle(39, 203, 5, 5);
        Rectangle smallPoint44 = new Rectangle(59, 203, 5, 5);
        Rectangle smallPoint45 = new Rectangle(79, 203, 5, 5);
        Rectangle smallPoint46 = new Rectangle(99, 203, 5, 5);
        Rectangle smallPoint47 = new Rectangle(119, 203, 5, 5);
        Rectangle smallPoint48 = new Rectangle(159, 203, 5, 5);
        Rectangle smallPoint49 = new Rectangle(179, 203, 5, 5);
        Rectangle smallPoint50 = new Rectangle(199, 203, 5, 5);
        Rectangle smallPoint51 = new Rectangle(219, 203, 5, 5);
        Rectangle smallPoint52 = new Rectangle(239, 203, 5, 5);
        Rectangle smallPoint53 = new Rectangle(259, 203, 5, 5);
        Rectangle smallPoint54 = new Rectangle(279, 203, 5, 5);
        Rectangle smallPoint55 = new Rectangle(299, 203, 5, 5);
        Rectangle smallPoint56 = new Rectangle(319, 203, 5, 5);
        Rectangle smallPoint57 = new Rectangle(339, 203, 5, 5);
        Rectangle smallPoint58 = new Rectangle(359, 203, 5, 5);
        Rectangle smallPoint59 = new Rectangle(379, 203, 5, 5);
        Rectangle smallPoint60 = new Rectangle(399, 203, 5, 5);
        Rectangle smallPoint61 = new Rectangle(419, 203, 5, 5);
        Rectangle smallPoint62 = new Rectangle(439, 203, 5, 5);
        Rectangle smallPoint63 = new Rectangle(459, 203, 5, 5);
        Rectangle smallPoint64 = new Rectangle(479, 203, 5, 5);
        Rectangle smallPoint65 = new Rectangle(499, 203, 5, 5);
        Rectangle smallPoint66 = new Rectangle(519, 203, 5, 5);
        Rectangle smallPoint67 = new Rectangle(179, 83, 5, 5);
        Rectangle smallPoint68 = new Rectangle(179, 103, 5, 5);
        Rectangle smallPoint69 = new Rectangle(179, 123, 5, 5);
        Rectangle smallPoint70 = new Rectangle(199, 83, 5, 5);
        Rectangle smallPoint71 = new Rectangle(219, 83, 5, 5);
        Rectangle smallPoint72 = new Rectangle(159, 123, 5, 5);
        Rectangle smallPoint73 = new Rectangle(239, 83, 5, 5);
        Rectangle smallPoint74 = new Rectangle(259, 83, 5, 5);
        Rectangle smallPoint75 = new Rectangle(279, 83, 5, 5);
        Rectangle smallPoint76 = new Rectangle(299, 83, 5, 5);
        Rectangle smallPoint77 = new Rectangle(319, 83, 5, 5);
        Rectangle smallPoint78 = new Rectangle(339, 83, 5, 5);
        Rectangle smallPoint79 = new Rectangle(359, 83, 5, 5);
        Rectangle smallPoint80 = new Rectangle(379, 83, 5, 5);
        Rectangle smallPoint81 = new Rectangle(319, 103, 5, 5);
        Rectangle smallPoint82 = new Rectangle(239, 103, 5, 5);
        Rectangle smallPoint83 = new Rectangle(379, 103, 5, 5);
        Rectangle smallPoint84 = new Rectangle(199, 123, 5, 5);
        Rectangle smallPoint85 = new Rectangle(219, 123, 5, 5);
        Rectangle smallPoint86 = new Rectangle(239, 123, 5, 5);
        Rectangle smallPoint87 = new Rectangle(259, 123, 5, 5);
        Rectangle smallPoint88 = new Rectangle(279, 123, 5, 5);
        Rectangle smallPoint89 = new Rectangle(299, 123, 5, 5);
        Rectangle smallPoint90 = new Rectangle(319, 123, 5, 5);
        Rectangle smallPoint91 = new Rectangle(339, 123, 5, 5);
        Rectangle smallPoint92 = new Rectangle(359, 123, 5, 5);
        Rectangle smallPoint93 = new Rectangle(379, 123, 5, 5);
        Rectangle smallPoint94 = new Rectangle(399, 123, 5, 5);
        Rectangle smallPoint95 = new Rectangle(199, 143, 5, 5);
        Rectangle smallPoint96 = new Rectangle(359, 143, 5, 5);
        Rectangle smallPoint97 = new Rectangle(159, 163, 5, 5);
        Rectangle smallPoint98 = new Rectangle(179, 163, 5, 5);
        Rectangle smallPoint99 = new Rectangle(199, 163, 5, 5);
        Rectangle smallPoint100 = new Rectangle(219, 163, 5, 5);
        Rectangle smallPoint101 = new Rectangle(239, 163, 5, 5);
        Rectangle smallPoint102 = new Rectangle(259, 163, 5, 5);
        Rectangle smallPoint103 = new Rectangle(299, 163, 5, 5);
        Rectangle smallPoint104 = new Rectangle(319, 163, 5, 5);
        Rectangle smallPoint105 = new Rectangle(339, 163, 5, 5);
        Rectangle smallPoint106 = new Rectangle(359, 163, 5, 5);
        Rectangle smallPoint107 = new Rectangle(379, 163, 5, 5);
        Rectangle smallPoint108 = new Rectangle(399, 163, 5, 5);
        Rectangle smallPoint109 = new Rectangle(259, 183, 5, 5);
        Rectangle smallPoint110 = new Rectangle(299, 183, 5, 5);
        Rectangle smallPoint111 = new Rectangle(419, 23, 5, 5);
        Rectangle smallPoint112 = new Rectangle(419, 43, 5, 5);
        Rectangle smallPoint113 = new Rectangle(419, 63, 5, 5);
        Rectangle smallPoint114 = new Rectangle(419, 83, 5, 5);
        Rectangle smallPoint115 = new Rectangle(419, 103, 5, 5);
        Rectangle smallPoint116 = new Rectangle(419, 123, 5, 5);
        Rectangle smallPoint117 = new Rectangle(419, 143, 5, 5);
        Rectangle smallPoint118 = new Rectangle(419, 163, 5, 5);
        Rectangle smallPoint119 = new Rectangle(419, 183, 5, 5);
        Rectangle smallPoint120 = new Rectangle(439, 23, 5, 5);
        Rectangle smallPoint121 = new Rectangle(459, 23, 5, 5);
        Rectangle smallPoint122 = new Rectangle(479, 23, 5, 5);
        Rectangle smallPoint123 = new Rectangle(499, 23, 5, 5);
        Rectangle smallPoint124 = new Rectangle(519, 23, 5, 5);
        Rectangle smallPoint125 = new Rectangle(539, 23, 5, 5);
        Rectangle smallPoint126 = new Rectangle(539, 43, 5, 5);
        Rectangle smallPoint127 = new Rectangle(539, 63, 5, 5);
        Rectangle smallPoint128 = new Rectangle(539, 83, 5, 5);
        Rectangle smallPoint129 = new Rectangle(539, 103, 5, 5);
        Rectangle smallPoint130 = new Rectangle(539, 123, 5, 5);
        Rectangle smallPoint131 = new Rectangle(539, 143, 5, 5);
        Rectangle smallPoint132 = new Rectangle(539, 163, 5, 5);
        Rectangle smallPoint133 = new Rectangle(539, 183, 5, 5);
        Rectangle smallPoint134 = new Rectangle(539, 203, 5, 5);
        Rectangle smallPoint135 = new Rectangle(459, 43, 5, 5);
        Rectangle smallPoint136 = new Rectangle(129, 218, 5, 5);
        Rectangle smallPoint137 = new Rectangle(479, 63, 5, 5);
        Rectangle smallPoint138 = new Rectangle(499, 63, 5, 5);
        Rectangle smallPoint139 = new Rectangle(519, 63, 5, 5);
        Rectangle smallPoint140 = new Rectangle(439, 103, 5, 5);
        Rectangle smallPoint141 = new Rectangle(459, 103, 5, 5);
        Rectangle smallPoint142 = new Rectangle(459, 123, 5, 5);
        Rectangle smallPoint143 = new Rectangle(459, 143, 5, 5);
        Rectangle smallPoint144 = new Rectangle(459, 163, 5, 5);
        Rectangle smallPoint145 = new Rectangle(459, 183, 5, 5);
        Rectangle smallPoint146 = new Rectangle(499, 103, 5, 5);
        Rectangle smallPoint147 = new Rectangle(499, 123, 5, 5);
        Rectangle smallPoint148 = new Rectangle(499, 143, 5, 5);
        Rectangle smallPoint149 = new Rectangle(499, 163, 5, 5);
        Rectangle smallPoint150 = new Rectangle(479, 163, 5, 5);
        Rectangle smallPoint151 = new Rectangle(519, 103, 5, 5);
        Rectangle smallPoint152 = new Rectangle(69, 218, 5, 5);
        Rectangle smallPoint153 = new Rectangle(69, 238, 5, 5);
        Rectangle smallPoint154 = new Rectangle(69, 258, 5, 5);
        Rectangle smallPoint155 = new Rectangle(69, 278, 5, 5);
        Rectangle smallPoint156 = new Rectangle(84, 263, 5, 5);
        Rectangle smallPoint157 = new Rectangle(99, 263, 5, 5);
        Rectangle smallPoint158 = new Rectangle(99, 233, 5, 5);
        Rectangle smallPoint159 = new Rectangle(114, 233, 5, 5);
        Rectangle smallPoint160 = new Rectangle(129, 238, 5, 5);
        Rectangle smallPoint161 = new Rectangle(129, 258, 5, 5);
        Rectangle smallPoint162 = new Rectangle(129, 278, 5, 5);
        Rectangle smallPoint163 = new Rectangle(189, 218, 5, 5);
        Rectangle smallPoint164 = new Rectangle(189, 238, 5, 5);
        Rectangle smallPoint165 = new Rectangle(189, 258, 5, 5);
        Rectangle smallPoint166 = new Rectangle(189, 278, 5, 5);
        Rectangle smallPoint167 = new Rectangle(219, 218, 5, 5);
        Rectangle smallPoint168 = new Rectangle(219, 238, 5, 5);
        Rectangle smallPoint169 = new Rectangle(249, 218, 5, 5);
        Rectangle smallPoint170 = new Rectangle(249, 238, 5, 5);
        Rectangle smallPoint171 = new Rectangle(249, 258, 5, 5);
        Rectangle smallPoint172 = new Rectangle(249, 278, 5, 5);
        Rectangle smallPoint173 = new Rectangle(264, 263, 5, 5);
        Rectangle smallPoint174 = new Rectangle(279, 233, 5, 5);
        Rectangle smallPoint175 = new Rectangle(279, 263, 5, 5);
        Rectangle smallPoint176 = new Rectangle(294, 233, 5, 5);
        Rectangle smallPoint177 = new Rectangle(309, 218, 5, 5);
        Rectangle smallPoint178 = new Rectangle(309, 238, 5, 5);
        Rectangle smallPoint179 = new Rectangle(309, 258, 5, 5);
        Rectangle smallPoint180 = new Rectangle(309, 278, 5, 5);
        Rectangle smallPoint181 = new Rectangle(339, 218, 5, 5);
        Rectangle smallPoint182 = new Rectangle(339, 238, 5, 5);
        Rectangle smallPoint183 = new Rectangle(399, 223, 5, 5);
        Rectangle smallPoint184 = new Rectangle(369, 218, 5, 5);
        Rectangle smallPoint185 = new Rectangle(369, 238, 5, 5);
        Rectangle smallPoint186 = new Rectangle(369, 258, 5, 5);
        Rectangle smallPoint187 = new Rectangle(369, 278, 5, 5);
        Rectangle smallPoint188 = new Rectangle(399, 273, 5, 5);
        Rectangle smallPoint189 = new Rectangle(429, 218, 5, 5);
        Rectangle smallPoint190 = new Rectangle(429, 238, 5, 5);
        Rectangle smallPoint191 = new Rectangle(429, 258, 5, 5);
        Rectangle smallPoint192 = new Rectangle(429, 278, 5, 5);
        Rectangle smallPoint193 = new Rectangle(489, 218, 5, 5);
        Rectangle smallPoint194 = new Rectangle(489, 238, 5, 5);
        Rectangle smallPoint195 = new Rectangle(489, 258, 5, 5);
        Rectangle smallPoint196 = new Rectangle(489, 278, 5, 5);
        Rectangle smallPoint197 = new Rectangle(459, 233, 5, 5);
        Rectangle smallPoint198 = new Rectangle(459, 263, 5, 5);
        Rectangle smallPoint199 = new Rectangle(474, 233, 5, 5);
        Rectangle smallPoint200 = new Rectangle(474, 263, 5, 5);
        Rectangle smallPoint201 = new Rectangle(19, 293, 5, 5);
        Rectangle smallPoint202 = new Rectangle(39, 293, 5, 5);
        Rectangle smallPoint203 = new Rectangle(59, 293, 5, 5);
        Rectangle smallPoint204 = new Rectangle(79, 293, 5, 5);
        Rectangle smallPoint205 = new Rectangle(99, 293, 5, 5);
        Rectangle smallPoint206 = new Rectangle(119, 293, 5, 5);
        Rectangle smallPoint207 = new Rectangle(139, 293, 5, 5);
        Rectangle smallPoint208 = new Rectangle(159, 293, 5, 5);
        Rectangle smallPoint209 = new Rectangle(179, 293, 5, 5);
        Rectangle smallPoint210 = new Rectangle(199, 293, 5, 5);
        Rectangle smallPoint211 = new Rectangle(219, 293, 5, 5);
        Rectangle smallPoint212 = new Rectangle(239, 293, 5, 5);
        Rectangle smallPoint213 = new Rectangle(259, 293, 5, 5);
        Rectangle smallPoint214 = new Rectangle(279, 293, 5, 5);
        Rectangle smallPoint215 = new Rectangle(299, 293, 5, 5);
        Rectangle smallPoint216 = new Rectangle(319, 293, 5, 5);
        Rectangle smallPoint217 = new Rectangle(339, 293, 5, 5);
        Rectangle smallPoint218 = new Rectangle(359, 293, 5, 5);
        Rectangle smallPoint219 = new Rectangle(379, 293, 5, 5);
        Rectangle smallPoint220 = new Rectangle(399, 293, 5, 5);
        Rectangle smallPoint221 = new Rectangle(419, 293, 5, 5);
        Rectangle smallPoint222 = new Rectangle(439, 293, 5, 5);
        Rectangle smallPoint223 = new Rectangle(459, 293, 5, 5);
        Rectangle smallPoint224 = new Rectangle(479, 293, 5, 5);
        Rectangle smallPoint225 = new Rectangle(499, 293, 5, 5);
        Rectangle smallPoint226 = new Rectangle(519, 293, 5, 5);
        Rectangle smallPoint227 = new Rectangle(539, 293, 5, 5);
        Rectangle smallPoint228 = new Rectangle(19, 313, 5, 5);
        Rectangle smallPoint229 = new Rectangle(119, 313, 5, 5);
        Rectangle smallPoint230 = new Rectangle(279, 313, 5, 5);
        Rectangle smallPoint231 = new Rectangle(439, 313, 5, 5);
        Rectangle smallPoint232 = new Rectangle(539, 313, 5, 5);
        Rectangle smallPoint233 = new Rectangle(19, 333, 5, 5);
        Rectangle smallPoint234 = new Rectangle(39, 333, 5, 5);
        Rectangle smallPoint235 = new Rectangle(59, 333, 5, 5);
        Rectangle smallPoint236 = new Rectangle(119, 333, 5, 5);
        Rectangle smallPoint237 = new Rectangle(139, 333, 5, 5);
        Rectangle smallPoint238 = new Rectangle(159, 333, 5, 5);
        Rectangle smallPoint239 = new Rectangle(199, 333, 5, 5);
        Rectangle smallPoint240 = new Rectangle(219, 333, 5, 5);
        Rectangle smallPoint241 = new Rectangle(239, 333, 5, 5);
        Rectangle smallPoint242 = new Rectangle(259, 333, 5, 5);
        Rectangle smallPoint243 = new Rectangle(299, 333, 5, 5);
        Rectangle smallPoint244 = new Rectangle(319, 333, 5, 5);
        Rectangle smallPoint245 = new Rectangle(339, 333, 5, 5);
        Rectangle smallPoint246 = new Rectangle(359, 333, 5, 5);
        Rectangle smallPoint247 = new Rectangle(399, 333, 5, 5);
        Rectangle smallPoint248 = new Rectangle(419, 333, 5, 5);
        Rectangle smallPoint249 = new Rectangle(439, 333, 5, 5);
        Rectangle smallPoint250 = new Rectangle(479, 333, 5, 5);
        Rectangle smallPoint251 = new Rectangle(499, 333, 5, 5);
        Rectangle smallPoint252 = new Rectangle(519, 333, 5, 5);
        Rectangle smallPoint253 = new Rectangle(539, 333, 5, 5);
        Rectangle smallPoint254 = new Rectangle(79, 333, 5, 5);
        Rectangle smallPoint255 = new Rectangle(279, 333, 5, 5);
        Rectangle smallPoint256 = new Rectangle(79, 353, 5, 5);
        Rectangle smallPoint257 = new Rectangle(119, 353, 5, 5);
        Rectangle smallPoint258 = new Rectangle(159, 353, 5, 5);
        Rectangle smallPoint259 = new Rectangle(199, 353, 5, 5);
        Rectangle smallPoint260 = new Rectangle(359, 353, 5, 5);
        Rectangle smallPoint261 = new Rectangle(399, 353, 5, 5);
        Rectangle smallPoint262 = new Rectangle(439, 353, 5, 5);
        Rectangle smallPoint263 = new Rectangle(479, 353, 5, 5);
        Rectangle smallPoint264 = new Rectangle(19, 373, 5, 5);
        Rectangle smallPoint265 = new Rectangle(39, 373, 5, 5);
        Rectangle smallPoint266 = new Rectangle(59, 373, 5, 5);
        Rectangle smallPoint267 = new Rectangle(79, 373, 5, 5);
        Rectangle smallPoint268 = new Rectangle(99, 373, 5, 5);
        Rectangle smallPoint269 = new Rectangle(159, 373, 5, 5);
        Rectangle smallPoint270 = new Rectangle(179, 373, 5, 5);
        Rectangle smallPoint271 = new Rectangle(199, 373, 5, 5);
        Rectangle smallPoint272 = new Rectangle(219, 373, 5, 5);
        Rectangle smallPoint273 = new Rectangle(239, 373, 5, 5);
        Rectangle smallPoint274 = new Rectangle(259, 373, 5, 5);
        Rectangle smallPoint275 = new Rectangle(279, 373, 5, 5);
        Rectangle smallPoint276 = new Rectangle(299, 373, 5, 5);
        Rectangle smallPoint277 = new Rectangle(319, 373, 5, 5);
        Rectangle smallPoint278 = new Rectangle(339, 373, 5, 5);
        Rectangle smallPoint279 = new Rectangle(359, 373, 5, 5);
        Rectangle smallPoint280 = new Rectangle(379, 373, 5, 5);
        Rectangle smallPoint281 = new Rectangle(399, 373, 5, 5);
        Rectangle smallPoint282 = new Rectangle(19, 393, 5, 5);
        Rectangle smallPoint283 = new Rectangle(459, 373, 5, 5);
        Rectangle smallPoint284 = new Rectangle(479, 373, 5, 5);
        Rectangle smallPoint285 = new Rectangle(499, 373, 5, 5);
        Rectangle smallPoint286 = new Rectangle(519, 373, 5, 5);
        Rectangle smallPoint287 = new Rectangle(539, 373, 5, 5);
        Rectangle smallPoint288 = new Rectangle(19, 413, 5, 5);
        Rectangle smallPoint289 = new Rectangle(179, 393, 5, 5);
        Rectangle smallPoint290 = new Rectangle(219, 393, 5, 5);
        Rectangle smallPoint291 = new Rectangle(339, 393, 5, 5);
        Rectangle smallPoint292 = new Rectangle(379, 393, 5, 5);
        Rectangle smallPoint293 = new Rectangle(539, 393, 5, 5);
        Rectangle smallPoint294 = new Rectangle(39, 413, 5, 5);
        Rectangle smallPoint295 = new Rectangle(59, 413, 5, 5);
        Rectangle smallPoint296 = new Rectangle(79, 413, 5, 5);
        Rectangle smallPoint297 = new Rectangle(99, 413, 5, 5);
        Rectangle smallPoint298 = new Rectangle(119, 413, 5, 5);
        Rectangle smallPoint299 = new Rectangle(139, 413, 5, 5);
        Rectangle smallPoint300 = new Rectangle(159, 413, 5, 5);
        Rectangle smallPoint301 = new Rectangle(179, 413, 5, 5);
        Rectangle smallPoint302 = new Rectangle(199, 413, 5, 5);
        Rectangle smallPoint303 = new Rectangle(219, 413, 5, 5);
        Rectangle smallPoint304 = new Rectangle(239, 413, 5, 5);
        Rectangle smallPoint305 = new Rectangle(259, 413, 5, 5);
        Rectangle smallPoint306 = new Rectangle(299, 413, 5, 5);
        Rectangle smallPoint307 = new Rectangle(319, 413, 5, 5);
        Rectangle smallPoint308 = new Rectangle(339, 413, 5, 5);
        Rectangle smallPoint309 = new Rectangle(359, 413, 5, 5);
        Rectangle smallPoint310 = new Rectangle(379, 413, 5, 5);
        Rectangle smallPoint311 = new Rectangle(399, 413, 5, 5);
        Rectangle smallPoint312 = new Rectangle(419, 413, 5, 5);
        Rectangle smallPoint313 = new Rectangle(439, 413, 5, 5);
        Rectangle smallPoint314 = new Rectangle(459, 413, 5, 5);
        Rectangle smallPoint315 = new Rectangle(479, 413, 5, 5);
        Rectangle smallPoint316 = new Rectangle(499, 413, 5, 5);
        Rectangle smallPoint317 = new Rectangle(519, 413, 5, 5);
        Rectangle smallPoint318 = new Rectangle(539, 413, 5, 5);
        Rectangle smallPoint319 = new Rectangle(19, 433, 5, 5);
        Rectangle smallPoint320 = new Rectangle(79, 433, 5, 5);
        Rectangle smallPoint321 = new Rectangle(219, 433, 5, 5);
        Rectangle smallPoint323 = new Rectangle(259, 433, 5, 5);
        Rectangle smallPoint324 = new Rectangle(299, 433, 5, 5);
        Rectangle smallPoint325 = new Rectangle(339, 433, 5, 5);
        Rectangle smallPoint326 = new Rectangle(479, 433, 5, 5);
        Rectangle smallPoint327 = new Rectangle(539, 433, 5, 5);
        Rectangle smallPoint328 = new Rectangle(19, 453, 5, 5);
        Rectangle smallPoint329 = new Rectangle(39, 453, 5, 5);
        Rectangle smallPoint330 = new Rectangle(59, 453, 5, 5);
        Rectangle smallPoint331 = new Rectangle(79, 453, 5, 5);
        Rectangle smallPoint332 = new Rectangle(99, 453, 5, 5);
        Rectangle smallPoint333 = new Rectangle(119, 453, 5, 5);
        Rectangle smallPoint334 = new Rectangle(139, 453, 5, 5);
        Rectangle smallPoint335 = new Rectangle(159, 453, 5, 5);
        Rectangle smallPoint336 = new Rectangle(179, 453, 5, 5);
        Rectangle smallPoint337 = new Rectangle(199, 453, 5, 5);
        Rectangle smallPoint338 = new Rectangle(219, 453, 5, 5);
        Rectangle smallPoint339 = new Rectangle(259, 453, 5, 5);
        Rectangle smallPoint340 = new Rectangle(299, 453, 5, 5);
        Rectangle smallPoint341 = new Rectangle(339, 453, 5, 5);
        Rectangle smallPoint342 = new Rectangle(359, 453, 5, 5);
        Rectangle smallPoint343 = new Rectangle(379, 453, 5, 5);
        Rectangle smallPoint344 = new Rectangle(399, 453, 5, 5);
        Rectangle smallPoint345 = new Rectangle(419, 453, 5, 5);
        Rectangle smallPoint346 = new Rectangle(439, 453, 5, 5);
        Rectangle smallPoint347 = new Rectangle(459, 453, 5, 5);
        Rectangle smallPoint348 = new Rectangle(479, 453, 5, 5);
        Rectangle smallPoint349 = new Rectangle(499, 453, 5, 5);
        Rectangle smallPoint350 = new Rectangle(519, 453, 5, 5);
        Rectangle smallPoint322 = new Rectangle(539, 453, 5, 5);

        Rectangle bigPoint1 = new Rectangle(92, 56, 15, 15);
        Rectangle bigPoint2 = new Rectangle(454, 56, 15, 15);
        Rectangle bigPoint3 = new Rectangle(213, 253, 15, 15);
        Rectangle bigPoint4 = new Rectangle(333, 253, 15, 15);
        Rectangle bigPoint5 = new Rectangle(113, 367, 15, 15);
        Rectangle bigPoint6 = new Rectangle(433, 367, 15, 15);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {
            if (situation == "start")
            {
                e.Graphics.FillPie(yellowBrush, startplayer, startplayerAngle1, startplayerAngle2);
            }
            else if (situation == "reset")
            {
            }
            else
            {
                //S
                e.Graphics.DrawLine(wordPen, 80, 215, 120, 215);
                e.Graphics.DrawLine(wordPen, 120, 215, 120, 225);
                e.Graphics.DrawLine(wordPen, 90, 225, 120, 225);
                e.Graphics.DrawLine(wordPen, 80, 215, 80, 255);
                e.Graphics.DrawLine(wordPen, 90, 225, 90, 245);
                e.Graphics.DrawLine(wordPen, 90, 245, 120, 245);
                e.Graphics.DrawLine(wordPen, 80, 255, 110, 255);
                e.Graphics.DrawLine(wordPen, 120, 245, 120, 285);
                e.Graphics.DrawLine(wordPen, 110, 255, 110, 275);
                e.Graphics.DrawLine(wordPen, 80, 275, 110, 275);
                e.Graphics.DrawLine(wordPen, 80, 285, 120, 285);
                e.Graphics.DrawLine(wordPen, 80, 275, 80, 285);
                //O
                e.Graphics.DrawLine(wordPen, 140, 215, 180, 215);
                e.Graphics.DrawLine(wordPen, 150, 225, 170, 225);
                e.Graphics.DrawLine(wordPen, 140, 215, 140, 285);
                e.Graphics.DrawLine(wordPen, 150, 225, 150, 275);
                e.Graphics.DrawLine(wordPen, 140, 285, 180, 285);
                e.Graphics.DrawLine(wordPen, 150, 275, 170, 275);
                e.Graphics.DrawLine(wordPen, 180, 215, 180, 285);
                e.Graphics.DrawLine(wordPen, 170, 225, 170, 275);
                //U
                e.Graphics.DrawLine(wordPen, 200, 215, 210, 215);
                e.Graphics.DrawLine(wordPen, 200, 215, 200, 285);
                e.Graphics.DrawLine(wordPen, 210, 215, 210, 275);
                e.Graphics.DrawLine(wordPen, 210, 275, 230, 275);
                e.Graphics.DrawLine(wordPen, 200, 285, 240, 285);
                e.Graphics.DrawLine(wordPen, 230, 215, 230, 275);
                e.Graphics.DrawLine(wordPen, 240, 215, 240, 285);
                e.Graphics.DrawLine(wordPen, 230, 215, 240, 215);
                //S
                e.Graphics.DrawLine(wordPen, 260, 215, 300, 215);
                e.Graphics.DrawLine(wordPen, 300, 215, 300, 225);
                e.Graphics.DrawLine(wordPen, 270, 225, 300, 225);
                e.Graphics.DrawLine(wordPen, 260, 215, 260, 255);
                e.Graphics.DrawLine(wordPen, 270, 225, 270, 245);
                e.Graphics.DrawLine(wordPen, 270, 245, 300, 245);
                e.Graphics.DrawLine(wordPen, 260, 255, 290, 255);
                e.Graphics.DrawLine(wordPen, 300, 245, 300, 285);
                e.Graphics.DrawLine(wordPen, 290, 255, 290, 275);
                e.Graphics.DrawLine(wordPen, 260, 275, 290, 275);
                e.Graphics.DrawLine(wordPen, 260, 285, 300, 285);
                e.Graphics.DrawLine(wordPen, 260, 275, 260, 285);
                //U
                e.Graphics.DrawLine(wordPen, 320, 215, 330, 215);
                e.Graphics.DrawLine(wordPen, 320, 215, 320, 285);
                e.Graphics.DrawLine(wordPen, 330, 215, 330, 275);
                e.Graphics.DrawLine(wordPen, 330, 275, 350, 275);
                e.Graphics.DrawLine(wordPen, 320, 285, 360, 285);
                e.Graphics.DrawLine(wordPen, 350, 215, 350, 275);
                e.Graphics.DrawLine(wordPen, 360, 215, 360, 285);
                e.Graphics.DrawLine(wordPen, 350, 215, 360, 215);
                //K
                e.Graphics.DrawLine(wordPen, 380, 215, 380, 285);
                e.Graphics.DrawLine(wordPen, 380, 215, 390, 215);
                e.Graphics.DrawLine(wordPen, 380, 285, 390, 285);
                e.Graphics.DrawLine(wordPen, 390, 215, 390, 240);
                e.Graphics.DrawLine(wordPen, 390, 260, 390, 285);
                e.Graphics.DrawLine(wordPen, 390, 240, 410, 240);
                e.Graphics.DrawLine(wordPen, 390, 260, 410, 260);
                e.Graphics.DrawLine(wordPen, 410, 240, 410, 260);
                e.Graphics.DrawLine(wordPen, 410, 215, 410, 240);
                e.Graphics.DrawLine(wordPen, 420, 215, 420, 240);
                e.Graphics.DrawLine(wordPen, 410, 215, 420, 215);
                e.Graphics.DrawLine(wordPen, 410, 240, 420, 240);
                e.Graphics.DrawLine(wordPen, 410, 260, 420, 260);
                e.Graphics.DrawLine(wordPen, 410, 285, 420, 285);
                e.Graphics.DrawLine(wordPen, 410, 260, 410, 285);
                e.Graphics.DrawLine(wordPen, 420, 260, 420, 285);
                //E
                e.Graphics.DrawLine(wordPen, 440, 215, 440, 285);
                e.Graphics.DrawLine(wordPen, 440, 215, 480, 215);
                e.Graphics.DrawLine(wordPen, 480, 215, 480, 225);
                e.Graphics.DrawLine(wordPen, 450, 225, 480, 225);
                e.Graphics.DrawLine(wordPen, 450, 225, 450, 245);
                e.Graphics.DrawLine(wordPen, 450, 245, 480, 245);
                e.Graphics.DrawLine(wordPen, 450, 255, 480, 255);
                e.Graphics.DrawLine(wordPen, 480, 245, 480, 255);
                e.Graphics.DrawLine(wordPen, 450, 255, 450, 275);
                e.Graphics.DrawLine(wordPen, 450, 275, 480, 275);
                e.Graphics.DrawLine(wordPen, 440, 285, 480, 285);
                e.Graphics.DrawLine(wordPen, 480, 275, 480, 285);

                //Map
                e.Graphics.DrawLine(edgePen, 10, 15, 10, 215);
                e.Graphics.DrawLine(edgePen, 10, 15, 150, 15);
                e.Graphics.DrawLine(edgePen, 150, 15, 150, 115);
                e.Graphics.DrawLine(edgePen, 170, 75, 170, 115);
                e.Graphics.DrawLine(edgePen, 150, 115, 170, 115);
                e.Graphics.DrawLine(edgePen, 170, 75, 390, 75);
                e.Graphics.DrawLine(edgePen, 390, 75, 390, 115);
                e.Graphics.DrawLine(edgePen, 390, 115, 410, 115);
                e.Graphics.DrawLine(edgePen, 410, 15, 410, 115);
                e.Graphics.DrawLine(edgePen, 410, 15, 550, 15);
                e.Graphics.DrawLine(edgePen, 550, 15, 550, 215);
                e.Graphics.DrawLine(edgePen, 500, 215, 550, 215);
                e.Graphics.DrawLine(edgePen, 500, 215, 500, 240);
                e.Graphics.DrawLine(edgePen, 500, 240, 560, 240);
                e.Graphics.DrawLine(edgePen, 500, 260, 560, 260);
                e.Graphics.DrawLine(edgePen, 500, 260, 500, 285);
                e.Graphics.DrawLine(edgePen, 500, 285, 550, 285);
                e.Graphics.DrawLine(edgePen, 550, 285, 550, 345);
                e.Graphics.DrawLine(edgePen, 490, 345, 550, 345);
                e.Graphics.DrawLine(edgePen, 490, 345, 490, 365);
                e.Graphics.DrawLine(edgePen, 490, 365, 550, 365);
                e.Graphics.DrawLine(edgePen, 550, 365, 550, 465);
                e.Graphics.DrawLine(edgePen, 10, 465, 230, 465);
                e.Graphics.DrawLine(edgePen, 230, 425, 230, 465);
                e.Graphics.DrawLine(edgePen, 250, 425, 250, 465);
                e.Graphics.DrawLine(edgePen, 230, 425, 250, 425);
                e.Graphics.DrawLine(edgePen, 250, 465, 310, 465);
                e.Graphics.DrawLine(edgePen, 310, 425, 310, 465);
                e.Graphics.DrawLine(edgePen, 330, 425, 330, 465);
                e.Graphics.DrawLine(edgePen, 310, 425, 330, 425);
                e.Graphics.DrawLine(edgePen, 330, 465, 550, 465);
                e.Graphics.DrawLine(edgePen, 10, 285, 10, 345);
                e.Graphics.DrawLine(edgePen, 10, 345, 70, 345);
                e.Graphics.DrawLine(edgePen, 10, 365, 70, 365);
                e.Graphics.DrawLine(edgePen, 70, 345, 70, 365);
                e.Graphics.DrawLine(edgePen, 10, 365, 10, 465);
                e.Graphics.DrawLine(edgePen, 10, 285, 60, 285);
                e.Graphics.DrawLine(edgePen, 60, 260, 60, 285);
                e.Graphics.DrawLine(edgePen, 0, 260, 60, 260);
                e.Graphics.DrawLine(edgePen, 0, 240, 60, 240);
                e.Graphics.DrawLine(edgePen, 10, 215, 60, 215);
                e.Graphics.DrawLine(edgePen, 60, 215, 60, 240);

                //TopLeft
                e.Graphics.DrawLine(edgePen, 30, 35, 90, 35);
                e.Graphics.DrawLine(edgePen, 30, 55, 90, 55);
                e.Graphics.DrawLine(edgePen, 30, 35, 30, 55);
                e.Graphics.DrawLine(edgePen, 90, 35, 90, 55);

                e.Graphics.DrawLine(edgePen, 110, 35, 110, 75);
                e.Graphics.DrawLine(edgePen, 110, 35, 130, 35);
                e.Graphics.DrawLine(edgePen, 130, 35, 130, 95);
                e.Graphics.DrawLine(edgePen, 30, 75, 30, 95);
                e.Graphics.DrawLine(edgePen, 30, 75, 110, 75);
                e.Graphics.DrawLine(edgePen, 30, 95, 70, 95);
                e.Graphics.DrawLine(edgePen, 70, 95, 70, 155);
                e.Graphics.DrawLine(edgePen, 70, 155, 90, 155);
                e.Graphics.DrawLine(edgePen, 90, 95, 90, 155);
                e.Graphics.DrawLine(edgePen, 90, 95, 130, 95);

                e.Graphics.DrawLine(edgePen, 30, 115, 30, 195);
                e.Graphics.DrawLine(edgePen, 30, 115, 50, 115);
                e.Graphics.DrawLine(edgePen, 50, 115, 50, 175);
                e.Graphics.DrawLine(edgePen, 50, 175, 90, 175);
                e.Graphics.DrawLine(edgePen, 90, 175, 90, 195);
                e.Graphics.DrawLine(edgePen, 30, 195, 90, 195);

                e.Graphics.DrawLine(edgePen, 110, 115, 110, 195);
                e.Graphics.DrawLine(edgePen, 130, 115, 130, 195);
                e.Graphics.DrawLine(edgePen, 110, 115, 130, 115);
                e.Graphics.DrawLine(edgePen, 110, 195, 130, 195);

                e.Graphics.DrawLine(edgePen, 150, 195, 250, 195);
                e.Graphics.DrawLine(edgePen, 150, 175, 250, 175);
                e.Graphics.DrawLine(edgePen, 150, 175, 150, 195);
                e.Graphics.DrawLine(edgePen, 250, 175, 250, 195);

                e.Graphics.DrawLine(edgePen, 150, 135, 190, 135);
                e.Graphics.DrawLine(edgePen, 150, 155, 190, 155);
                e.Graphics.DrawLine(edgePen, 150, 135, 150, 155);
                e.Graphics.DrawLine(edgePen, 190, 135, 190, 155);

                //TopRight
                e.Graphics.DrawLine(edgePen, 470, 35, 530, 35);
                e.Graphics.DrawLine(edgePen, 470, 55, 530, 55);
                e.Graphics.DrawLine(edgePen, 470, 35, 470, 55);
                e.Graphics.DrawLine(edgePen, 530, 35, 530, 55);

                e.Graphics.DrawLine(edgePen, 430, 35, 450, 35);
                e.Graphics.DrawLine(edgePen, 430, 35, 430, 95);
                e.Graphics.DrawLine(edgePen, 450, 35, 450, 75);
                e.Graphics.DrawLine(edgePen, 450, 75, 530, 75);
                e.Graphics.DrawLine(edgePen, 530, 75, 530, 95);
                e.Graphics.DrawLine(edgePen, 490, 95, 530, 95);
                e.Graphics.DrawLine(edgePen, 490, 95, 490, 155);
                e.Graphics.DrawLine(edgePen, 470, 95, 470, 155);
                e.Graphics.DrawLine(edgePen, 470, 155, 490, 155);
                e.Graphics.DrawLine(edgePen, 430, 95, 470, 95);

                e.Graphics.DrawLine(edgePen, 530, 115, 530, 195);
                e.Graphics.DrawLine(edgePen, 510, 115, 510, 175);
                e.Graphics.DrawLine(edgePen, 510, 115, 530, 115);
                e.Graphics.DrawLine(edgePen, 470, 175, 510, 175);
                e.Graphics.DrawLine(edgePen, 470, 175, 470, 195);
                e.Graphics.DrawLine(edgePen, 470, 195, 530, 195);

                e.Graphics.DrawLine(edgePen, 430, 115, 430, 195);
                e.Graphics.DrawLine(edgePen, 450, 115, 450, 195);
                e.Graphics.DrawLine(edgePen, 430, 115, 450, 115);
                e.Graphics.DrawLine(edgePen, 430, 195, 450, 195);

                e.Graphics.DrawLine(edgePen, 310, 175, 310, 195);
                e.Graphics.DrawLine(edgePen, 310, 175, 410, 175);
                e.Graphics.DrawLine(edgePen, 310, 195, 410, 195);
                e.Graphics.DrawLine(edgePen, 410, 175, 410, 195);

                e.Graphics.DrawLine(edgePen, 370, 135, 410, 135);
                e.Graphics.DrawLine(edgePen, 370, 155, 410, 155);
                e.Graphics.DrawLine(edgePen, 370, 135, 370, 155);
                e.Graphics.DrawLine(edgePen, 410, 135, 410, 155);

                //TopMiddle
                e.Graphics.DrawLine(edgePen, 210, 135, 350, 135);
                e.Graphics.DrawLine(edgePen, 210, 135, 210, 155);
                e.Graphics.DrawLine(edgePen, 350, 135, 350, 155);
                e.Graphics.DrawLine(edgePen, 210, 155, 270, 155);
                e.Graphics.DrawLine(edgePen, 270, 155, 270, 195);
                e.Graphics.DrawLine(edgePen, 290, 155, 290, 195);
                e.Graphics.DrawLine(edgePen, 270, 195, 290, 195);
                e.Graphics.DrawLine(edgePen, 290, 155, 350, 155);

                e.Graphics.DrawLine(edgePen, 190, 95, 230, 95);
                e.Graphics.DrawLine(edgePen, 190, 115, 230, 115);
                e.Graphics.DrawLine(edgePen, 190, 95, 190, 115);
                e.Graphics.DrawLine(edgePen, 230, 95, 230, 115);

                e.Graphics.DrawLine(edgePen, 330, 95, 370, 95);
                e.Graphics.DrawLine(edgePen, 330, 115, 370, 115);
                e.Graphics.DrawLine(edgePen, 330, 95, 330, 115);
                e.Graphics.DrawLine(edgePen, 370, 95, 370, 115);

                e.Graphics.DrawLine(edgePen, 250, 95, 310, 95);
                e.Graphics.DrawLine(edgePen, 250, 115, 310, 115);
                e.Graphics.DrawLine(edgePen, 250, 95, 250, 115);
                e.Graphics.DrawLine(edgePen, 310, 95, 310, 115);

                //BottomLeft
                e.Graphics.DrawLine(edgePen, 30, 305, 110, 305);
                e.Graphics.DrawLine(edgePen, 30, 325, 90, 325);
                e.Graphics.DrawLine(edgePen, 30, 305, 30, 325);
                e.Graphics.DrawLine(edgePen, 90, 325, 90, 365);
                e.Graphics.DrawLine(edgePen, 110, 305, 110, 365);
                e.Graphics.DrawLine(edgePen, 90, 365, 110, 365);

                e.Graphics.DrawLine(edgePen, 30, 385, 130, 385);
                e.Graphics.DrawLine(edgePen, 130, 345, 130, 385);
                e.Graphics.DrawLine(edgePen, 150, 345, 150, 385);
                e.Graphics.DrawLine(edgePen, 130, 345, 150, 345);
                e.Graphics.DrawLine(edgePen, 150, 385, 170, 385);
                e.Graphics.DrawLine(edgePen, 30, 405, 170, 405);
                e.Graphics.DrawLine(edgePen, 30, 385, 30, 405);
                e.Graphics.DrawLine(edgePen, 170, 385, 170, 405);

                e.Graphics.DrawLine(edgePen, 130, 305, 270, 305);
                e.Graphics.DrawLine(edgePen, 130, 325, 170, 325);
                e.Graphics.DrawLine(edgePen, 130, 305, 130, 325);
                e.Graphics.DrawLine(edgePen, 170, 325, 170, 365);
                e.Graphics.DrawLine(edgePen, 190, 325, 190, 365);
                e.Graphics.DrawLine(edgePen, 170, 365, 190, 365);
                e.Graphics.DrawLine(edgePen, 190, 325, 270, 325);
                e.Graphics.DrawLine(edgePen, 270, 305, 270, 325);

                e.Graphics.DrawLine(edgePen, 30, 425, 70, 425);
                e.Graphics.DrawLine(edgePen, 30, 445, 70, 445);
                e.Graphics.DrawLine(edgePen, 30, 425, 30, 445);
                e.Graphics.DrawLine(edgePen, 70, 425, 70, 445);

                e.Graphics.DrawLine(edgePen, 90, 425, 90, 445);
                e.Graphics.DrawLine(edgePen, 90, 425, 210, 425);
                e.Graphics.DrawLine(edgePen, 90, 445, 210, 445);
                e.Graphics.DrawLine(edgePen, 210, 425, 210, 445);

                //BottomRight
                e.Graphics.DrawLine(edgePen, 450, 305, 530, 305);
                e.Graphics.DrawLine(edgePen, 470, 325, 530, 325);
                e.Graphics.DrawLine(edgePen, 450, 305, 450, 365);
                e.Graphics.DrawLine(edgePen, 470, 325, 470, 365);
                e.Graphics.DrawLine(edgePen, 450, 365, 470, 365);
                e.Graphics.DrawLine(edgePen, 530, 305, 530, 325);

                e.Graphics.DrawLine(edgePen, 430, 385, 530, 385);
                e.Graphics.DrawLine(edgePen, 430, 345, 430, 385);
                e.Graphics.DrawLine(edgePen, 410, 345, 410, 385);
                e.Graphics.DrawLine(edgePen, 430, 345, 410, 345);
                e.Graphics.DrawLine(edgePen, 410, 385, 390, 385);
                e.Graphics.DrawLine(edgePen, 530, 405, 390, 405);
                e.Graphics.DrawLine(edgePen, 530, 385, 530, 405);
                e.Graphics.DrawLine(edgePen, 390, 385, 390, 405);

                e.Graphics.DrawLine(edgePen, 290, 305, 430, 305);
                e.Graphics.DrawLine(edgePen, 290, 305, 290, 325);
                e.Graphics.DrawLine(edgePen, 290, 325, 370, 325);
                e.Graphics.DrawLine(edgePen, 370, 325, 370, 365);
                e.Graphics.DrawLine(edgePen, 390, 325, 390, 365);
                e.Graphics.DrawLine(edgePen, 370, 365, 390, 365);
                e.Graphics.DrawLine(edgePen, 390, 325, 430, 325);
                e.Graphics.DrawLine(edgePen, 430, 305, 430, 325);

                e.Graphics.DrawLine(edgePen, 490, 425, 530, 425);
                e.Graphics.DrawLine(edgePen, 490, 445, 530, 445);
                e.Graphics.DrawLine(edgePen, 490, 425, 490, 445);
                e.Graphics.DrawLine(edgePen, 530, 425, 530, 445);

                e.Graphics.DrawLine(edgePen, 350, 425, 470, 425);
                e.Graphics.DrawLine(edgePen, 350, 445, 470, 445);
                e.Graphics.DrawLine(edgePen, 350, 425, 350, 445);
                e.Graphics.DrawLine(edgePen, 470, 425, 470, 445);

                //BottomMiddium
                e.Graphics.DrawLine(edgePen, 210, 345, 350, 345);
                e.Graphics.DrawLine(edgePen, 210, 365, 350, 365);
                e.Graphics.DrawLine(edgePen, 210, 345, 210, 365);
                e.Graphics.DrawLine(edgePen, 350, 345, 350, 365);

                e.Graphics.DrawLine(edgePen, 230, 385, 330, 385);
                e.Graphics.DrawLine(edgePen, 230, 385, 230, 405);
                e.Graphics.DrawLine(edgePen, 330, 385, 330, 405);
                e.Graphics.DrawLine(edgePen, 230, 405, 270, 405);
                e.Graphics.DrawLine(edgePen, 270, 405, 270, 445);
                e.Graphics.DrawLine(edgePen, 290, 405, 290, 445);
                e.Graphics.DrawLine(edgePen, 270, 445, 290, 445);
                e.Graphics.DrawLine(edgePen, 290, 405, 330, 405);

                e.Graphics.DrawLine(edgePen, 190, 385, 210, 385);
                e.Graphics.DrawLine(edgePen, 190, 405, 210, 405);
                e.Graphics.DrawLine(edgePen, 190, 385, 190, 405);
                e.Graphics.DrawLine(edgePen, 210, 385, 210, 405);

                e.Graphics.DrawLine(edgePen, 350, 385, 370, 385);
                e.Graphics.DrawLine(edgePen, 350, 405, 370, 405);
                e.Graphics.DrawLine(edgePen, 350, 385, 350, 405);
                e.Graphics.DrawLine(edgePen, 370, 385, 370, 405);

                //Player
                e.Graphics.FillPie(yellowBrush, player, playerAngle1, playerAngle2);

                //Life
                if (life == 3)
                {
                    e.Graphics.FillPie(yellowBrush, life1, 210, 300);
                    e.Graphics.FillPie(yellowBrush, life2, 210, 300);
                    e.Graphics.FillPie(yellowBrush, life3, 210, 300);
                }
                else if (life == 2)
                {
                    e.Graphics.FillPie(yellowBrush, life1, 210, 300);
                    e.Graphics.FillPie(yellowBrush, life2, 210, 300);
                }
                else if (life == 1)
                {
                    e.Graphics.FillPie(yellowBrush, life1, 210, 300);
                }

                //Enemy
                Rectangle enemy1 = new Rectangle(enemy1X, enemy1Y, 16, 16);
                Rectangle enemy2 = new Rectangle(enemy2X, enemy2Y, 16, 16);
                Rectangle enemy3 = new Rectangle(enemy3X, enemy3Y, 16, 16);
                Rectangle enemy4 = new Rectangle(enemy4X, enemy4Y, 16, 16);
                Rectangle enemy5 = new Rectangle(enemy5X, enemy5Y, 16, 16);
                Rectangle enemy6 = new Rectangle(enemy6X, enemy6Y, 16, 16);
                Rectangle enemy7 = new Rectangle(enemy7X, enemy7Y, 16, 16);
                Rectangle enemy8 = new Rectangle(enemy8X, enemy8Y, 16, 16);
                enemy1Pic.Location = new Point(enemy1X, enemy1Y);
                enemy2Pic.Location = new Point(enemy2X, enemy2Y);
                enemy3Pic.Location = new Point(enemy3X, enemy3Y);
                enemy4Pic.Location = new Point(enemy4X, enemy4Y);
                enemy5Pic.Location = new Point(enemy5X, enemy5Y);
                enemy6Pic.Location = new Point(enemy6X, enemy6Y);
                enemy7Pic.Location = new Point(enemy7X, enemy7Y);
                enemy8Pic.Location = new Point(enemy8X, enemy8Y);
                e.Graphics.FillRectangle(transparentBrush, enemy1);
                e.Graphics.FillRectangle(transparentBrush, enemy2);
                e.Graphics.FillRectangle(transparentBrush, enemy3);
                e.Graphics.FillRectangle(transparentBrush, enemy4);
                e.Graphics.FillRectangle(transparentBrush, enemy5);
                e.Graphics.FillRectangle(transparentBrush, enemy6);
                e.Graphics.FillRectangle(transparentBrush, enemy7);
                e.Graphics.FillRectangle(transparentBrush, enemy8);

                //Point
                e.Graphics.FillRectangle(pointBrush, smallPoint1);
                e.Graphics.FillRectangle(pointBrush, smallPoint2);
                e.Graphics.FillRectangle(pointBrush, smallPoint3);
                e.Graphics.FillRectangle(pointBrush, smallPoint4);
                e.Graphics.FillRectangle(pointBrush, smallPoint5);
                e.Graphics.FillRectangle(pointBrush, smallPoint6);
                e.Graphics.FillRectangle(pointBrush, smallPoint7);
                e.Graphics.FillRectangle(pointBrush, smallPoint8);
                e.Graphics.FillRectangle(pointBrush, smallPoint9);
                e.Graphics.FillRectangle(pointBrush, smallPoint10);
                e.Graphics.FillRectangle(pointBrush, smallPoint11);
                e.Graphics.FillRectangle(pointBrush, smallPoint12);
                e.Graphics.FillRectangle(pointBrush, smallPoint13);
                e.Graphics.FillRectangle(pointBrush, smallPoint14);
                e.Graphics.FillRectangle(pointBrush, smallPoint15);
                e.Graphics.FillRectangle(pointBrush, smallPoint16);
                e.Graphics.FillRectangle(pointBrush, smallPoint17);
                e.Graphics.FillRectangle(pointBrush, smallPoint18);
                e.Graphics.FillRectangle(pointBrush, smallPoint19);
                e.Graphics.FillRectangle(pointBrush, smallPoint20);
                e.Graphics.FillRectangle(pointBrush, smallPoint21);
                e.Graphics.FillRectangle(pointBrush, smallPoint22);
                e.Graphics.FillRectangle(pointBrush, smallPoint23);
                e.Graphics.FillRectangle(pointBrush, smallPoint24);
                e.Graphics.FillRectangle(pointBrush, smallPoint25);
                e.Graphics.FillRectangle(pointBrush, smallPoint26);
                e.Graphics.FillRectangle(pointBrush, smallPoint27);
                e.Graphics.FillRectangle(pointBrush, smallPoint28);
                e.Graphics.FillRectangle(pointBrush, smallPoint29);
                e.Graphics.FillRectangle(pointBrush, smallPoint30);
                e.Graphics.FillRectangle(pointBrush, smallPoint31);
                e.Graphics.FillRectangle(pointBrush, smallPoint32);
                e.Graphics.FillRectangle(pointBrush, smallPoint33);
                e.Graphics.FillRectangle(pointBrush, smallPoint34);
                e.Graphics.FillRectangle(pointBrush, smallPoint35);
                e.Graphics.FillRectangle(pointBrush, smallPoint36);
                e.Graphics.FillRectangle(pointBrush, smallPoint37);
                e.Graphics.FillRectangle(pointBrush, smallPoint38);
                e.Graphics.FillRectangle(pointBrush, smallPoint39);
                e.Graphics.FillRectangle(pointBrush, smallPoint40);
                e.Graphics.FillRectangle(pointBrush, smallPoint41);
                e.Graphics.FillRectangle(pointBrush, smallPoint42);
                e.Graphics.FillRectangle(pointBrush, smallPoint43);
                e.Graphics.FillRectangle(pointBrush, smallPoint44);
                e.Graphics.FillRectangle(pointBrush, smallPoint45);
                e.Graphics.FillRectangle(pointBrush, smallPoint46);
                e.Graphics.FillRectangle(pointBrush, smallPoint47);
                e.Graphics.FillRectangle(pointBrush, smallPoint48);
                e.Graphics.FillRectangle(pointBrush, smallPoint49);
                e.Graphics.FillRectangle(pointBrush, smallPoint50);
                e.Graphics.FillRectangle(pointBrush, smallPoint51);
                e.Graphics.FillRectangle(pointBrush, smallPoint52);
                e.Graphics.FillRectangle(pointBrush, smallPoint53);
                e.Graphics.FillRectangle(pointBrush, smallPoint54);
                e.Graphics.FillRectangle(pointBrush, smallPoint55);
                e.Graphics.FillRectangle(pointBrush, smallPoint56);
                e.Graphics.FillRectangle(pointBrush, smallPoint57);
                e.Graphics.FillRectangle(pointBrush, smallPoint58);
                e.Graphics.FillRectangle(pointBrush, smallPoint59);
                e.Graphics.FillRectangle(pointBrush, smallPoint60);
                e.Graphics.FillRectangle(pointBrush, smallPoint61);
                e.Graphics.FillRectangle(pointBrush, smallPoint62);
                e.Graphics.FillRectangle(pointBrush, smallPoint63);
                e.Graphics.FillRectangle(pointBrush, smallPoint64);
                e.Graphics.FillRectangle(pointBrush, smallPoint65);
                e.Graphics.FillRectangle(pointBrush, smallPoint66);
                e.Graphics.FillRectangle(pointBrush, smallPoint67);
                e.Graphics.FillRectangle(pointBrush, smallPoint68);
                e.Graphics.FillRectangle(pointBrush, smallPoint69);
                e.Graphics.FillRectangle(pointBrush, smallPoint70);
                e.Graphics.FillRectangle(pointBrush, smallPoint71);
                e.Graphics.FillRectangle(pointBrush, smallPoint72);
                e.Graphics.FillRectangle(pointBrush, smallPoint73);
                e.Graphics.FillRectangle(pointBrush, smallPoint74);
                e.Graphics.FillRectangle(pointBrush, smallPoint75);
                e.Graphics.FillRectangle(pointBrush, smallPoint76);
                e.Graphics.FillRectangle(pointBrush, smallPoint77);
                e.Graphics.FillRectangle(pointBrush, smallPoint78);
                e.Graphics.FillRectangle(pointBrush, smallPoint79);
                e.Graphics.FillRectangle(pointBrush, smallPoint80);
                e.Graphics.FillRectangle(pointBrush, smallPoint81);
                e.Graphics.FillRectangle(pointBrush, smallPoint82);
                e.Graphics.FillRectangle(pointBrush, smallPoint83);
                e.Graphics.FillRectangle(pointBrush, smallPoint84);
                e.Graphics.FillRectangle(pointBrush, smallPoint85);
                e.Graphics.FillRectangle(pointBrush, smallPoint86);
                e.Graphics.FillRectangle(pointBrush, smallPoint87);
                e.Graphics.FillRectangle(pointBrush, smallPoint88);
                e.Graphics.FillRectangle(pointBrush, smallPoint89);
                e.Graphics.FillRectangle(pointBrush, smallPoint90);
                e.Graphics.FillRectangle(pointBrush, smallPoint91);
                e.Graphics.FillRectangle(pointBrush, smallPoint92);
                e.Graphics.FillRectangle(pointBrush, smallPoint93);
                e.Graphics.FillRectangle(pointBrush, smallPoint94);
                e.Graphics.FillRectangle(pointBrush, smallPoint95);
                e.Graphics.FillRectangle(pointBrush, smallPoint96);
                e.Graphics.FillRectangle(pointBrush, smallPoint97);
                e.Graphics.FillRectangle(pointBrush, smallPoint98);
                e.Graphics.FillRectangle(pointBrush, smallPoint99);
                e.Graphics.FillRectangle(pointBrush, smallPoint100);
                e.Graphics.FillRectangle(pointBrush, smallPoint101);
                e.Graphics.FillRectangle(pointBrush, smallPoint102);
                e.Graphics.FillRectangle(pointBrush, smallPoint103);
                e.Graphics.FillRectangle(pointBrush, smallPoint104);
                e.Graphics.FillRectangle(pointBrush, smallPoint105);
                e.Graphics.FillRectangle(pointBrush, smallPoint106);
                e.Graphics.FillRectangle(pointBrush, smallPoint107);
                e.Graphics.FillRectangle(pointBrush, smallPoint108);
                e.Graphics.FillRectangle(pointBrush, smallPoint109);
                e.Graphics.FillRectangle(pointBrush, smallPoint110);
                e.Graphics.FillRectangle(pointBrush, smallPoint111);
                e.Graphics.FillRectangle(pointBrush, smallPoint112);
                e.Graphics.FillRectangle(pointBrush, smallPoint113);
                e.Graphics.FillRectangle(pointBrush, smallPoint114);
                e.Graphics.FillRectangle(pointBrush, smallPoint115);
                e.Graphics.FillRectangle(pointBrush, smallPoint116);
                e.Graphics.FillRectangle(pointBrush, smallPoint117);
                e.Graphics.FillRectangle(pointBrush, smallPoint118);
                e.Graphics.FillRectangle(pointBrush, smallPoint119);
                e.Graphics.FillRectangle(pointBrush, smallPoint120);
                e.Graphics.FillRectangle(pointBrush, smallPoint121);
                e.Graphics.FillRectangle(pointBrush, smallPoint122);
                e.Graphics.FillRectangle(pointBrush, smallPoint123);
                e.Graphics.FillRectangle(pointBrush, smallPoint124);
                e.Graphics.FillRectangle(pointBrush, smallPoint125);
                e.Graphics.FillRectangle(pointBrush, smallPoint126);
                e.Graphics.FillRectangle(pointBrush, smallPoint127);
                e.Graphics.FillRectangle(pointBrush, smallPoint128);
                e.Graphics.FillRectangle(pointBrush, smallPoint129);
                e.Graphics.FillRectangle(pointBrush, smallPoint130);
                e.Graphics.FillRectangle(pointBrush, smallPoint131);
                e.Graphics.FillRectangle(pointBrush, smallPoint132);
                e.Graphics.FillRectangle(pointBrush, smallPoint133);
                e.Graphics.FillRectangle(pointBrush, smallPoint134);
                e.Graphics.FillRectangle(pointBrush, smallPoint135);
                e.Graphics.FillRectangle(pointBrush, smallPoint136);
                e.Graphics.FillRectangle(pointBrush, smallPoint137);
                e.Graphics.FillRectangle(pointBrush, smallPoint138);
                e.Graphics.FillRectangle(pointBrush, smallPoint139);
                e.Graphics.FillRectangle(pointBrush, smallPoint140);
                e.Graphics.FillRectangle(pointBrush, smallPoint141);
                e.Graphics.FillRectangle(pointBrush, smallPoint142);
                e.Graphics.FillRectangle(pointBrush, smallPoint143);
                e.Graphics.FillRectangle(pointBrush, smallPoint144);
                e.Graphics.FillRectangle(pointBrush, smallPoint145);
                e.Graphics.FillRectangle(pointBrush, smallPoint146);
                e.Graphics.FillRectangle(pointBrush, smallPoint147);
                e.Graphics.FillRectangle(pointBrush, smallPoint148);
                e.Graphics.FillRectangle(pointBrush, smallPoint149);
                e.Graphics.FillRectangle(pointBrush, smallPoint150);
                e.Graphics.FillRectangle(pointBrush, smallPoint151);
                e.Graphics.FillRectangle(pointBrush, smallPoint152);
                e.Graphics.FillRectangle(pointBrush, smallPoint153);
                e.Graphics.FillRectangle(pointBrush, smallPoint154);
                e.Graphics.FillRectangle(pointBrush, smallPoint155);
                e.Graphics.FillRectangle(pointBrush, smallPoint156);
                e.Graphics.FillRectangle(pointBrush, smallPoint157);
                e.Graphics.FillRectangle(pointBrush, smallPoint158);
                e.Graphics.FillRectangle(pointBrush, smallPoint159);
                e.Graphics.FillRectangle(pointBrush, smallPoint160);
                e.Graphics.FillRectangle(pointBrush, smallPoint161);
                e.Graphics.FillRectangle(pointBrush, smallPoint162);
                e.Graphics.FillRectangle(pointBrush, smallPoint163);
                e.Graphics.FillRectangle(pointBrush, smallPoint164);
                e.Graphics.FillRectangle(pointBrush, smallPoint165);
                e.Graphics.FillRectangle(pointBrush, smallPoint166);
                e.Graphics.FillRectangle(pointBrush, smallPoint167);
                e.Graphics.FillRectangle(pointBrush, smallPoint168);
                e.Graphics.FillRectangle(pointBrush, smallPoint169);
                e.Graphics.FillRectangle(pointBrush, smallPoint170);
                e.Graphics.FillRectangle(pointBrush, smallPoint171);
                e.Graphics.FillRectangle(pointBrush, smallPoint172);
                e.Graphics.FillRectangle(pointBrush, smallPoint173);
                e.Graphics.FillRectangle(pointBrush, smallPoint174);
                e.Graphics.FillRectangle(pointBrush, smallPoint175);
                e.Graphics.FillRectangle(pointBrush, smallPoint176);
                e.Graphics.FillRectangle(pointBrush, smallPoint177);
                e.Graphics.FillRectangle(pointBrush, smallPoint178);
                e.Graphics.FillRectangle(pointBrush, smallPoint179);
                e.Graphics.FillRectangle(pointBrush, smallPoint180);
                e.Graphics.FillRectangle(pointBrush, smallPoint181);
                e.Graphics.FillRectangle(pointBrush, smallPoint182);
                e.Graphics.FillRectangle(pointBrush, smallPoint183);
                e.Graphics.FillRectangle(pointBrush, smallPoint184);
                e.Graphics.FillRectangle(pointBrush, smallPoint185);
                e.Graphics.FillRectangle(pointBrush, smallPoint186);
                e.Graphics.FillRectangle(pointBrush, smallPoint187);
                e.Graphics.FillRectangle(pointBrush, smallPoint188);
                e.Graphics.FillRectangle(pointBrush, smallPoint189);
                e.Graphics.FillRectangle(pointBrush, smallPoint190);
                e.Graphics.FillRectangle(pointBrush, smallPoint191);
                e.Graphics.FillRectangle(pointBrush, smallPoint192);
                e.Graphics.FillRectangle(pointBrush, smallPoint193);
                e.Graphics.FillRectangle(pointBrush, smallPoint194);
                e.Graphics.FillRectangle(pointBrush, smallPoint195);
                e.Graphics.FillRectangle(pointBrush, smallPoint196);
                e.Graphics.FillRectangle(pointBrush, smallPoint197);
                e.Graphics.FillRectangle(pointBrush, smallPoint198);
                e.Graphics.FillRectangle(pointBrush, smallPoint199);
                e.Graphics.FillRectangle(pointBrush, smallPoint200);
                e.Graphics.FillRectangle(pointBrush, smallPoint201);
                e.Graphics.FillRectangle(pointBrush, smallPoint202);
                e.Graphics.FillRectangle(pointBrush, smallPoint203);
                e.Graphics.FillRectangle(pointBrush, smallPoint204);
                e.Graphics.FillRectangle(pointBrush, smallPoint205);
                e.Graphics.FillRectangle(pointBrush, smallPoint206);
                e.Graphics.FillRectangle(pointBrush, smallPoint207);
                e.Graphics.FillRectangle(pointBrush, smallPoint208);
                e.Graphics.FillRectangle(pointBrush, smallPoint209);
                e.Graphics.FillRectangle(pointBrush, smallPoint210);
                e.Graphics.FillRectangle(pointBrush, smallPoint211);
                e.Graphics.FillRectangle(pointBrush, smallPoint212);
                e.Graphics.FillRectangle(pointBrush, smallPoint213);
                e.Graphics.FillRectangle(pointBrush, smallPoint214);
                e.Graphics.FillRectangle(pointBrush, smallPoint215);
                e.Graphics.FillRectangle(pointBrush, smallPoint216);
                e.Graphics.FillRectangle(pointBrush, smallPoint217);
                e.Graphics.FillRectangle(pointBrush, smallPoint218);
                e.Graphics.FillRectangle(pointBrush, smallPoint219);
                e.Graphics.FillRectangle(pointBrush, smallPoint220);
                e.Graphics.FillRectangle(pointBrush, smallPoint221);
                e.Graphics.FillRectangle(pointBrush, smallPoint222);
                e.Graphics.FillRectangle(pointBrush, smallPoint223);
                e.Graphics.FillRectangle(pointBrush, smallPoint224);
                e.Graphics.FillRectangle(pointBrush, smallPoint225);
                e.Graphics.FillRectangle(pointBrush, smallPoint226);
                e.Graphics.FillRectangle(pointBrush, smallPoint227);
                e.Graphics.FillRectangle(pointBrush, smallPoint228);
                e.Graphics.FillRectangle(pointBrush, smallPoint229);
                e.Graphics.FillRectangle(pointBrush, smallPoint230);
                e.Graphics.FillRectangle(pointBrush, smallPoint231);
                e.Graphics.FillRectangle(pointBrush, smallPoint232);
                e.Graphics.FillRectangle(pointBrush, smallPoint233);
                e.Graphics.FillRectangle(pointBrush, smallPoint234);
                e.Graphics.FillRectangle(pointBrush, smallPoint235);
                e.Graphics.FillRectangle(pointBrush, smallPoint236);
                e.Graphics.FillRectangle(pointBrush, smallPoint237);
                e.Graphics.FillRectangle(pointBrush, smallPoint238);
                e.Graphics.FillRectangle(pointBrush, smallPoint239);
                e.Graphics.FillRectangle(pointBrush, smallPoint240);
                e.Graphics.FillRectangle(pointBrush, smallPoint241);
                e.Graphics.FillRectangle(pointBrush, smallPoint242);
                e.Graphics.FillRectangle(pointBrush, smallPoint243);
                e.Graphics.FillRectangle(pointBrush, smallPoint244);
                e.Graphics.FillRectangle(pointBrush, smallPoint245);
                e.Graphics.FillRectangle(pointBrush, smallPoint246);
                e.Graphics.FillRectangle(pointBrush, smallPoint247);
                e.Graphics.FillRectangle(pointBrush, smallPoint248);
                e.Graphics.FillRectangle(pointBrush, smallPoint249);
                e.Graphics.FillRectangle(pointBrush, smallPoint250);
                e.Graphics.FillRectangle(pointBrush, smallPoint251);
                e.Graphics.FillRectangle(pointBrush, smallPoint252);
                e.Graphics.FillRectangle(pointBrush, smallPoint253);
                e.Graphics.FillRectangle(pointBrush, smallPoint254);
                e.Graphics.FillRectangle(pointBrush, smallPoint255);
                e.Graphics.FillRectangle(pointBrush, smallPoint256);
                e.Graphics.FillRectangle(pointBrush, smallPoint257);
                e.Graphics.FillRectangle(pointBrush, smallPoint258);
                e.Graphics.FillRectangle(pointBrush, smallPoint259);
                e.Graphics.FillRectangle(pointBrush, smallPoint260);
                e.Graphics.FillRectangle(pointBrush, smallPoint261);
                e.Graphics.FillRectangle(pointBrush, smallPoint262);
                e.Graphics.FillRectangle(pointBrush, smallPoint263);
                e.Graphics.FillRectangle(pointBrush, smallPoint264);
                e.Graphics.FillRectangle(pointBrush, smallPoint265);
                e.Graphics.FillRectangle(pointBrush, smallPoint266);
                e.Graphics.FillRectangle(pointBrush, smallPoint267);
                e.Graphics.FillRectangle(pointBrush, smallPoint268);
                e.Graphics.FillRectangle(pointBrush, smallPoint269);
                e.Graphics.FillRectangle(pointBrush, smallPoint270);
                e.Graphics.FillRectangle(pointBrush, smallPoint271);
                e.Graphics.FillRectangle(pointBrush, smallPoint272);
                e.Graphics.FillRectangle(pointBrush, smallPoint273);
                e.Graphics.FillRectangle(pointBrush, smallPoint274);
                e.Graphics.FillRectangle(pointBrush, smallPoint275);
                e.Graphics.FillRectangle(pointBrush, smallPoint276);
                e.Graphics.FillRectangle(pointBrush, smallPoint277);
                e.Graphics.FillRectangle(pointBrush, smallPoint278);
                e.Graphics.FillRectangle(pointBrush, smallPoint279);
                e.Graphics.FillRectangle(pointBrush, smallPoint280);
                e.Graphics.FillRectangle(pointBrush, smallPoint281);
                e.Graphics.FillRectangle(pointBrush, smallPoint282);
                e.Graphics.FillRectangle(pointBrush, smallPoint283);
                e.Graphics.FillRectangle(pointBrush, smallPoint284);
                e.Graphics.FillRectangle(pointBrush, smallPoint285);
                e.Graphics.FillRectangle(pointBrush, smallPoint286);
                e.Graphics.FillRectangle(pointBrush, smallPoint287);
                e.Graphics.FillRectangle(pointBrush, smallPoint288);
                e.Graphics.FillRectangle(pointBrush, smallPoint289);
                e.Graphics.FillRectangle(pointBrush, smallPoint290);
                e.Graphics.FillRectangle(pointBrush, smallPoint291);
                e.Graphics.FillRectangle(pointBrush, smallPoint292);
                e.Graphics.FillRectangle(pointBrush, smallPoint293);
                e.Graphics.FillRectangle(pointBrush, smallPoint294);
                e.Graphics.FillRectangle(pointBrush, smallPoint295);
                e.Graphics.FillRectangle(pointBrush, smallPoint296);
                e.Graphics.FillRectangle(pointBrush, smallPoint297);
                e.Graphics.FillRectangle(pointBrush, smallPoint298);
                e.Graphics.FillRectangle(pointBrush, smallPoint299);
                e.Graphics.FillRectangle(pointBrush, smallPoint300);
                e.Graphics.FillRectangle(pointBrush, smallPoint301);
                e.Graphics.FillRectangle(pointBrush, smallPoint302);
                e.Graphics.FillRectangle(pointBrush, smallPoint303);
                e.Graphics.FillRectangle(pointBrush, smallPoint304);
                e.Graphics.FillRectangle(pointBrush, smallPoint305);
                e.Graphics.FillRectangle(pointBrush, smallPoint306);
                e.Graphics.FillRectangle(pointBrush, smallPoint307);
                e.Graphics.FillRectangle(pointBrush, smallPoint308);
                e.Graphics.FillRectangle(pointBrush, smallPoint309);
                e.Graphics.FillRectangle(pointBrush, smallPoint310);
                e.Graphics.FillRectangle(pointBrush, smallPoint311);
                e.Graphics.FillRectangle(pointBrush, smallPoint312);
                e.Graphics.FillRectangle(pointBrush, smallPoint313);
                e.Graphics.FillRectangle(pointBrush, smallPoint314);
                e.Graphics.FillRectangle(pointBrush, smallPoint315);
                e.Graphics.FillRectangle(pointBrush, smallPoint316);
                e.Graphics.FillRectangle(pointBrush, smallPoint317);
                e.Graphics.FillRectangle(pointBrush, smallPoint318);
                e.Graphics.FillRectangle(pointBrush, smallPoint319);
                e.Graphics.FillRectangle(pointBrush, smallPoint320);
                e.Graphics.FillRectangle(pointBrush, smallPoint321);
                e.Graphics.FillRectangle(pointBrush, smallPoint322);
                e.Graphics.FillRectangle(pointBrush, smallPoint323);
                e.Graphics.FillRectangle(pointBrush, smallPoint324);
                e.Graphics.FillRectangle(pointBrush, smallPoint325);
                e.Graphics.FillRectangle(pointBrush, smallPoint326);
                e.Graphics.FillRectangle(pointBrush, smallPoint327);
                e.Graphics.FillRectangle(pointBrush, smallPoint328);
                e.Graphics.FillRectangle(pointBrush, smallPoint329);
                e.Graphics.FillRectangle(pointBrush, smallPoint330);
                e.Graphics.FillRectangle(pointBrush, smallPoint331);
                e.Graphics.FillRectangle(pointBrush, smallPoint332);
                e.Graphics.FillRectangle(pointBrush, smallPoint333);
                e.Graphics.FillRectangle(pointBrush, smallPoint334);
                e.Graphics.FillRectangle(pointBrush, smallPoint335);
                e.Graphics.FillRectangle(pointBrush, smallPoint336);
                e.Graphics.FillRectangle(pointBrush, smallPoint337);
                e.Graphics.FillRectangle(pointBrush, smallPoint338);
                e.Graphics.FillRectangle(pointBrush, smallPoint339);
                e.Graphics.FillRectangle(pointBrush, smallPoint340);
                e.Graphics.FillRectangle(pointBrush, smallPoint341);
                e.Graphics.FillRectangle(pointBrush, smallPoint342);
                e.Graphics.FillRectangle(pointBrush, smallPoint343);
                e.Graphics.FillRectangle(pointBrush, smallPoint344);
                e.Graphics.FillRectangle(pointBrush, smallPoint345);
                e.Graphics.FillRectangle(pointBrush, smallPoint346);
                e.Graphics.FillRectangle(pointBrush, smallPoint347);
                e.Graphics.FillRectangle(pointBrush, smallPoint348);
                e.Graphics.FillRectangle(pointBrush, smallPoint349);
                e.Graphics.FillRectangle(pointBrush, smallPoint350);


                e.Graphics.FillPie(bigpointBrush, bigPoint1, 0, 360);
                e.Graphics.FillPie(bigpointBrush, bigPoint2, 0, 360);
                e.Graphics.FillPie(bigpointBrush, bigPoint3, 0, 360);
                e.Graphics.FillPie(bigpointBrush, bigPoint4, 0, 360);
                e.Graphics.FillPie(bigpointBrush, bigPoint5, 0, 360);
                e.Graphics.FillPie(bigpointBrush, bigPoint6, 0, 360);
            }
        }

        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up = false;
                    break;
                case Keys.Down:
                    down = false;
                    break;
                case Keys.Left:
                    left = false;
                    break;
                case Keys.Right:
                    right = false;
                    break;
                case Keys.Space:
                    space = false;
                    break;
            }
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    up = true;
                    break;
                case Keys.Down:
                    down = true;
                    break;
                case Keys.Left:
                    left = true;
                    break;
                case Keys.Right:
                    right = true;
                    break;
                case Keys.Space:
                    space = true;
                    break;
            }
        }

        private void playerTimer_Tick_1(object sender, EventArgs e)
        {
            switch (situation)
            {
                case "start":
                    startTimer.Enabled = true;
                    enemy1Pic.Visible = false;
                    enemy2Pic.Visible = false;
                    enemy3Pic.Visible = false;
                    enemy4Pic.Visible = false;
                    enemy5Pic.Visible = false;
                    enemy6Pic.Visible = false;
                    enemy7Pic.Visible = false;
                    enemy8Pic.Visible = false;
                    enemy1Pic.BackgroundImage = Properties.Resources.enemy1D;
                    enemy2Pic.BackgroundImage = Properties.Resources.enemy2D;
                    enemy3Pic.BackgroundImage = Properties.Resources.enemy3D;
                    enemy4Pic.BackgroundImage = Properties.Resources.enemy4D;
                    enemy5Pic.BackgroundImage = Properties.Resources.enemy5D;
                    enemy6Pic.BackgroundImage = Properties.Resources.enemy6D;
                    enemy7Pic.BackgroundImage = Properties.Resources.enemy7D;
                    enemy8Pic.BackgroundImage = Properties.Resources.enemy8D;
                    break;

                case "playing":
                    menuLabel.Visible = false;
                    enemy1Pic.Visible = true;
                    enemy2Pic.Visible = true;
                    enemy3Pic.Visible = true;
                    enemy4Pic.Visible = true;
                    enemy5Pic.Visible = true;
                    enemy6Pic.Visible = true;
                    enemy7Pic.Visible = true;
                    enemy8Pic.Visible = true;
                    //Bottom
                    if (player.Location == new Point(13, 287))
                    {
                        playerLocation = "B1";
                    }
                    else if (player.Location == new Point(113, 287))
                    {
                        playerLocation = "B2";
                    }
                    else if (player.Location == new Point(273, 287))
                    {
                        playerLocation = "B3";
                    }
                    else if (player.Location == new Point(433, 287))
                    {
                        playerLocation = "B4";
                    }
                    else if (player.Location == new Point(533, 287))
                    {
                        playerLocation = "B5";
                    }
                    else if (player.Location == new Point(13, 327))
                    {
                        playerLocation = "B6";
                    }
                    else if (player.Location == new Point(73, 327))
                    {
                        playerLocation = "B7";
                    }
                    else if (player.Location == new Point(113, 327))
                    {
                        playerLocation = "B8";
                    }
                    else if (player.Location == new Point(153, 327))
                    {
                        playerLocation = "B9";
                    }
                    else if (player.Location == new Point(193, 327))
                    {
                        playerLocation = "B10";
                    }
                    else if (player.Location == new Point(273, 327))
                    {
                        playerLocation = "B11";
                    }
                    else if (player.Location == new Point(353, 327))
                    {
                        playerLocation = "B12";
                    }
                    else if (player.Location == new Point(393, 327))
                    {
                        playerLocation = "B13";
                    }
                    else if (player.Location == new Point(433, 327))
                    {
                        playerLocation = "B14";
                    }
                    else if (player.Location == new Point(473, 327))
                    {
                        playerLocation = "B15";
                    }
                    else if (player.Location == new Point(533, 327))
                    {
                        playerLocation = "B16";
                    }
                    else if (player.Location == new Point(13, 367))
                    {
                        playerLocation = "B17";
                    }
                    else if (player.Location == new Point(73, 367))
                    {
                        playerLocation = "B18";
                    }
                    else if (player.Location == new Point(113, 367))
                    {
                        playerLocation = "B19";
                    }
                    else if (player.Location == new Point(153, 367))
                    {
                        playerLocation = "B20";
                    }
                    else if (player.Location == new Point(173, 367))
                    {
                        playerLocation = "B21";
                    }
                    else if (player.Location == new Point(193, 367))
                    {
                        playerLocation = "B22";
                    }
                    else if (player.Location == new Point(213, 367))
                    {
                        playerLocation = "B23";
                    }
                    else if (player.Location == new Point(333, 367))
                    {
                        playerLocation = "B24";
                    }
                    else if (player.Location == new Point(353, 367))
                    {
                        playerLocation = "B25";
                    }
                    else if (player.Location == new Point(373, 367))
                    {
                        playerLocation = "B26";
                    }
                    else if (player.Location == new Point(393, 367))
                    {
                        playerLocation = "B27";
                    }
                    else if (player.Location == new Point(433, 367))
                    {
                        playerLocation = "B28";
                    }
                    else if (player.Location == new Point(473, 367))
                    {
                        playerLocation = "B29";
                    }
                    else if (player.Location == new Point(533, 367))
                    {
                        playerLocation = "B30";
                    }
                    else if (player.Location == new Point(13, 407))
                    {
                        playerLocation = "B31";
                    }
                    else if (player.Location == new Point(73, 407))
                    {
                        playerLocation = "B32";
                    }
                    else if (player.Location == new Point(173, 407))
                    {
                        playerLocation = "B33";
                    }
                    else if (player.Location == new Point(213, 407))
                    {
                        playerLocation = "B34";
                    }
                    else if (player.Location == new Point(253, 407))
                    {
                        playerLocation = "B35";
                    }
                    else if (player.Location == new Point(293, 407))
                    {
                        playerLocation = "B36";
                    }
                    else if (player.Location == new Point(333, 407))
                    {
                        playerLocation = "B37";
                    }
                    else if (player.Location == new Point(373, 407))
                    {
                        playerLocation = "B38";
                    }
                    else if (player.Location == new Point(473, 407))
                    {
                        playerLocation = "B39";
                    }
                    else if (player.Location == new Point(533, 407))
                    {
                        playerLocation = "B40";
                    }
                    else if (player.Location == new Point(13, 447))
                    {
                        playerLocation = "B41";
                    }
                    else if (player.Location == new Point(73, 447))
                    {
                        playerLocation = "B42";
                    }
                    else if (player.Location == new Point(213, 447))
                    {
                        playerLocation = "B43";
                    }
                    else if (player.Location == new Point(253, 447))
                    {
                        playerLocation = "B44";
                    }
                    else if (player.Location == new Point(293, 447))
                    {
                        playerLocation = "B45";
                    }
                    else if (player.Location == new Point(333, 447))
                    {
                        playerLocation = "B46";
                    }
                    else if (player.Location == new Point(473, 447))
                    {
                        playerLocation = "B47";
                    }
                    else if (player.Location == new Point(533, 447))
                    {
                        playerLocation = "B48";
                    }

                    //Middle
                    else if (player.Location == new Point(63, 197))
                    {
                        playerLocation = "M1";
                    }
                    else if (player.Location == new Point(123, 197))
                    {
                        playerLocation = "M2";
                    }
                    else if (player.Location == new Point(183, 197))
                    {
                        playerLocation = "M3";
                    }
                    else if (player.Location == new Point(213, 197))
                    {
                        playerLocation = "M4";
                    }
                    else if (player.Location == new Point(243, 197))
                    {
                        playerLocation = "M5";
                    }
                    else if (player.Location == new Point(303, 197))
                    {
                        playerLocation = "M6";
                    }
                    else if (player.Location == new Point(333, 197))
                    {
                        playerLocation = "M7";
                    }
                    else if (player.Location == new Point(363, 197))
                    {
                        playerLocation = "M8";
                    }
                    else if (player.Location == new Point(393, 197))
                    {
                        playerLocation = "M9";
                    }
                    else if (player.Location == new Point(423, 197))
                    {
                        playerLocation = "M10";
                    }
                    else if (player.Location == new Point(483, 197))
                    {
                        playerLocation = "M11";
                    }
                    else if (player.Location == new Point(123, 227))
                    {
                        playerLocation = "M12";
                    }
                    else if (player.Location == new Point(303, 227))
                    {
                        playerLocation = "M13";
                    }
                    else if (player.Location == new Point(483, 227))
                    {
                        playerLocation = "M14";
                    }
                    else if (player.Location == new Point(63, 242))
                    {
                        playerLocation = "M15";
                    }
                    else if (player.Location == new Point(423, 242))
                    {
                        playerLocation = "M16";
                    }
                    else if (player.Location == new Point(483, 242))
                    {
                        playerLocation = "M17";
                    }
                    else if (player.Location == new Point(63, 257))
                    {
                        playerLocation = "M18";
                    }
                    else if (player.Location == new Point(243, 257))
                    {
                        playerLocation = "M19";
                    }
                    else if (player.Location == new Point(483, 257))
                    {
                        playerLocation = "M20";
                    }
                    else if (player.Location == new Point(63, 287))
                    {
                        playerLocation = "M21";
                    }
                    else if (player.Location == new Point(123, 287))
                    {
                        playerLocation = "M22";
                    }
                    else if (player.Location == new Point(183, 287))
                    {
                        playerLocation = "M23";
                    }
                    else if (player.Location == new Point(243, 287))
                    {
                        playerLocation = "M24";
                    }
                    else if (player.Location == new Point(303, 287))
                    {
                        playerLocation = "M25";
                    }
                    else if (player.Location == new Point(363, 287))
                    {
                        playerLocation = "M26";
                    }
                    else if (player.Location == new Point(393, 287))
                    {
                        playerLocation = "M27";
                    }
                    else if (player.Location == new Point(423, 287))
                    {
                        playerLocation = "M28";
                    }
                    else if (player.Location == new Point(483, 287))
                    {
                        playerLocation = "M29";
                    }

                    //Top
                    else if (player.Location == new Point(13, 17))
                    {
                        playerLocation = "T1";
                    }
                    else if (player.Location == new Point(93, 17))
                    {
                        playerLocation = "T2";
                    }
                    else if (player.Location == new Point(133, 17))
                    {
                        playerLocation = "T3";
                    }
                    else if (player.Location == new Point(13, 57))
                    {
                        playerLocation = "T4";
                    }
                    else if (player.Location == new Point(93, 57))
                    {
                        playerLocation = "T5";
                    }
                    else if (player.Location == new Point(13, 97))
                    {
                        playerLocation = "T6";
                    }
                    else if (player.Location == new Point(53, 97))
                    {
                        playerLocation = "T7";
                    }
                    else if (player.Location == new Point(93, 97))
                    {
                        playerLocation = "T8";
                    }
                    else if (player.Location == new Point(133, 97))
                    {
                        playerLocation = "T9";
                    }
                    else if (player.Location == new Point(53, 157))
                    {
                        playerLocation = "T10";
                    }
                    else if (player.Location == new Point(93, 157))
                    {
                        playerLocation = "T11";
                    }
                    else if (player.Location == new Point(13, 197))
                    {
                        playerLocation = "T12";
                    }
                    else if (player.Location == new Point(93, 197))
                    {
                        playerLocation = "T13";
                    }
                    else if (player.Location == new Point(133, 117))
                    {
                        playerLocation = "T14";
                    }
                    else if (player.Location == new Point(133, 157))
                    {
                        playerLocation = "T15";
                    }
                    else if (player.Location == new Point(133, 197))
                    {
                        playerLocation = "T16";
                    }
                    else if (player.Location == new Point(173, 77))
                    {
                        playerLocation = "T17";
                    }
                    else if (player.Location == new Point(173, 117))
                    {
                        playerLocation = "T18";
                    }
                    else if (player.Location == new Point(193, 117))
                    {
                        playerLocation = "T19";
                    }
                    else if (player.Location == new Point(193, 157))
                    {
                        playerLocation = "T20";
                    }
                    else if (player.Location == new Point(233, 77))
                    {
                        playerLocation = "T21";
                    }
                    else if (player.Location == new Point(233, 117))
                    {
                        playerLocation = "T22";
                    }
                    else if (player.Location == new Point(253, 157))
                    {
                        playerLocation = "T23";
                    }
                    else if (player.Location == new Point(253, 197))
                    {
                        playerLocation = "T24";
                    }
                    else if (player.Location == new Point(293, 157))
                    {
                        playerLocation = "T25";
                    }
                    else if (player.Location == new Point(293, 197))
                    {
                        playerLocation = "T26";
                    }
                    else if (player.Location == new Point(313, 77))
                    {
                        playerLocation = "T27";
                    }
                    else if (player.Location == new Point(313, 117))
                    {
                        playerLocation = "T28";
                    }
                    else if (player.Location == new Point(353, 117))
                    {
                        playerLocation = "T29";
                    }
                    else if (player.Location == new Point(353, 157))
                    {
                        playerLocation = "T30";
                    }
                    else if (player.Location == new Point(373, 77))
                    {
                        playerLocation = "T31";
                    }
                    else if (player.Location == new Point(373, 117))
                    {
                        playerLocation = "T32";
                    }
                    else if (player.Location == new Point(413, 117))
                    {
                        playerLocation = "T33";
                    }
                    else if (player.Location == new Point(413, 157))
                    {
                        playerLocation = "T34";
                    }
                    else if (player.Location == new Point(413, 197))
                    {
                        playerLocation = "T35";
                    }
                    else if (player.Location == new Point(413, 17))
                    {
                        playerLocation = "T36";
                    }
                    else if (player.Location == new Point(453, 17))
                    {
                        playerLocation = "T37";
                    }
                    else if (player.Location == new Point(533, 17))
                    {
                        playerLocation = "T38";
                    }
                    else if (player.Location == new Point(453, 57))
                    {
                        playerLocation = "T39";
                    }
                    else if (player.Location == new Point(533, 57))
                    {
                        playerLocation = "T40";
                    }
                    else if (player.Location == new Point(413, 97))
                    {
                        playerLocation = "T41";
                    }
                    else if (player.Location == new Point(453, 97))
                    {
                        playerLocation = "T42";
                    }
                    else if (player.Location == new Point(493, 97))
                    {
                        playerLocation = "T43";
                    }
                    else if (player.Location == new Point(533, 97))
                    {
                        playerLocation = "T44";
                    }
                    else if (player.Location == new Point(453, 157))
                    {
                        playerLocation = "T45";
                    }
                    else if (player.Location == new Point(493, 157))
                    {
                        playerLocation = "T46";
                    }
                    else if (player.Location == new Point(453, 197))
                    {
                        playerLocation = "T47";
                    }
                    else if (player.Location == new Point(533, 197))
                    {
                        playerLocation = "T48";
                    }

                    //Start
                    else if (player.Location == new Point(273, 447))
                    {
                        playerLocation = "start";
                    }

                    //Warp
                    else if (player.Location == new Point(-20, 242))
                    {
                        playerLocation = "warpL";
                    }
                    else if (player.Location == new Point(560, 242))
                    {
                        playerLocation = "warpR";
                    }
                    else if (player.Location == new Point(-19, 242))
                    {
                        playerLocation = "W1";
                    }
                    else if (player.Location == new Point(559, 242))
                    {
                        playerLocation = "W2";
                    }

                    switch (playerLocation)
                    {
                        //Bottom
                        case "B1":
                            if (up == true && player.Y > 287 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 327 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B2":
                            if (up == true && player.Y > 287 && player.X == 113)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 113)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B3":
                            if (up == true && player.Y > 287 && player.X == 273)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 327 && player.X == 273)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B4":
                            if (up == true && player.Y > 287 && player.X == 433)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 433)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B5":
                            if (up == true && player.Y > 287 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 327 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B6":
                            if (up == true && player.Y > 287 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 327 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 73 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B7":
                            if (up == true && player.Y > 327 && player.X == 73)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 73)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "left";
                            }

                            if (right == true && player.X < 73 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B8":
                            if (right == true && player.X < 153 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 113 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 287 && player.X == 113)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 113)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "B9":
                            if (up == true && player.Y > 327 && player.X == 153)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 153)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 153 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 113 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B10":
                            if (up == true && player.Y > 327 && player.X == 193)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 193)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 353 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 193 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B11":
                            if (up == true && player.Y > 287 && player.X == 273)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 327 && player.X == 273)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 353 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 193 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B12":
                            if (up == true && player.Y > 327 && player.X == 353)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 353)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 353 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 193 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B13":
                            if (up == true && player.Y > 327 && player.X == 393)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 393)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 433 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 393 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B14":
                            if (right == true && player.X < 433 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 393 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 287 && player.X == 433)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 433)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "B15":
                            if (up == true && player.Y > 327 && player.X == 473)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 473)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 473 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B16":
                            if (up == true && player.Y > 287 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 327 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 327)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 473 && player.Y == 327)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B17":
                            if (up == true && player.Y > 367 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 113 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B18":
                            if (up == true && player.Y > 327 && player.X == 73)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 73)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 113 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B19":
                            if (up == true && player.Y > 287 && player.X == 113)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 113)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 113 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B20":
                            if (up == true && player.Y > 327 && player.X == 153)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 153)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B21":
                            if (up == true && player.Y > 367 && player.X == 173)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 407 && player.X == 173)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B22":
                            if (up == true && player.Y > 327 && player.X == 193)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 193)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B23":
                            if (up == true && player.Y > 367 && player.X == 213)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 213)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B24":
                            if (up == true && player.Y > 367 && player.X == 333)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 333)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B25":
                            if (up == true && player.Y > 327 && player.X == 353)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 353)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B26":
                            if (up == true && player.Y > 367 && player.X == 373)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 407 && player.X == 373)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B27":
                            if (up == true && player.Y > 327 && player.X == 393)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 393)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 393 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 153 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B28":
                            if (up == true && player.Y > 287 && player.X == 433)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 433)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 433 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B29":
                            if (up == true && player.Y > 327 && player.X == 473)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 367 && player.X == 473)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 433 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B30":
                            if (up == true && player.Y > 367 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 367)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 433 && player.Y == 367)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B31":
                            if (right == true && player.X < 253 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 367 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "B32":
                            if (up == true && player.Y > 407 && player.X == 73)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 73)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 253 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B33":
                            if (up == true && player.Y > 367 && player.X == 173)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 407 && player.X == 173)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 253 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B34":
                            if (up == true && player.Y > 367 && player.X == 213)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 213)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 253 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B35":
                            if (up == true && player.Y > 407 && player.X == 253)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 253)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 253 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B36":
                            if (up == true && player.Y > 407 && player.X == 293)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 293)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B37":
                            if (up == true && player.Y > 367 && player.X == 333)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 333)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B38":
                            if (up == true && player.Y > 367 && player.X == 373)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 407 && player.X == 373)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B39":
                            if (up == true && player.Y > 407 && player.X == 473)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 473)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B40":
                            if (right == true && player.X < 533 && player.Y == 407)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 407)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 367 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "B41":
                            if (up == true && player.Y > 367 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 213 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B42":
                            if (up == true && player.Y > 407 && player.X == 73)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 73)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 213 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B43":
                            if (up == true && player.Y > 367 && player.X == 213)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 213)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 213 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B44":
                            if (up == true && player.Y > 407 && player.X == 253)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 253)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 293 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 253 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B45":
                            if (up == true && player.Y > 407 && player.X == 293)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 293)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 293 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 253 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B46":
                            if (up == true && player.Y > 367 && player.X == 333)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 333)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 333 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B47":
                            if (up == true && player.Y > 407 && player.X == 473)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 473)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 333 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "B48":
                            if (up == true && player.Y > 367 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 447 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 333 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;

                        //Middle
                        case "M1":
                            if (up == true && player.Y > 197 && player.X == 63)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 63)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M2":
                            if (up == true && player.Y > 197 && player.X == 123)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 123)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M3":
                            if (up == true && player.Y > 197 && player.X == 183)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 183)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M4":
                            if (up == true && player.Y > 197 && player.X == 213)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 257 && player.X == 213)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M5":
                            if (up == true && player.Y > 197 && player.X == 243)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 243)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M6":
                            if (up == true && player.Y > 197 && player.X == 303)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 303)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M7":
                            if (up == true && player.Y > 197 && player.X == 333)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 257 && player.X == 333)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M8":
                            if (up == true && player.Y > 197 && player.X == 363)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 363)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M9":
                            if (up == true && player.Y > 197 && player.X == 393)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 222 && player.X == 393)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M10":
                            if (up == true && player.Y > 197 && player.X == 423)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 423)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M11":
                            if (up == true && player.Y > 197 && player.X == 483)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 483)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M12":
                            if (right == true && player.X < 123 && player.Y == 227)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 93 && player.Y == 227)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 123)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 123)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M13":
                            if (right == true && player.X < 303 && player.Y == 227)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 273 && player.Y == 227)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 303)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 303)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M14":
                            if (right == true && player.X < 483 && player.Y == 227)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 453 && player.Y == 227)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 483)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 483)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M15":
                            if (right == true && player.X < 63 && player.Y == 242)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > -20 && player.Y == 242)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 63)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 63)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M16":
                            if (right == true && player.X < 423 && player.Y == 242)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 413 && player.Y == 242)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 423)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 423)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M17":
                            if (right == true && player.X < 560 && player.Y == 242)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 483 && player.Y == 242)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 483)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 483)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M18":
                            if (right == true && player.X < 93 && player.Y == 257)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 63 && player.Y == 257)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 63)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 63)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M19":
                            if (right == true && player.X < 273 && player.Y == 257)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 243 && player.Y == 257)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 243)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 243)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M20":
                            if (right == true && player.X < 483 && player.Y == 257)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 453 && player.Y == 257)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 197 && player.X == 483)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 483)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "M21":
                            if (up == true && player.Y > 197 && player.X == 63)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 63)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M22":
                            if (up == true && player.Y > 197 && player.X == 123)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 123)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M23":
                            if (up == true && player.Y > 197 && player.X == 183)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 183)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M24":
                            if (up == true && player.Y > 197 && player.X == 243)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 243)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M25":
                            if (up == true && player.Y > 197 && player.X == 303)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 303)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M26":
                            if (up == true && player.Y > 197 && player.X == 363)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 363)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M27":
                            if (up == true && player.Y > 262 && player.X == 393)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 393)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M28":
                            if (up == true && player.Y > 197 && player.X == 423)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 423)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "M29":
                            if (up == true && player.Y > 197 && player.X == 483)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 287 && player.X == 483)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 287)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 287)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;

                        //Top
                        case "T1":
                            if (up == true && player.Y > 17 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 133 && player.Y == 17)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 17)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T2":
                            if (up == true && player.Y > 17 && player.X == 93)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 57 && player.X == 93)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 133 && player.Y == 17)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 17)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T3":
                            if (up == true && player.Y > 17 && player.X == 133)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 133)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 133 && player.Y == 17)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 17)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T4":
                            if (right == true && player.X < 93 && player.Y == 57)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 57)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T5":
                            if (up == true && player.Y > 17 && player.X == 93)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 57 && player.X == 93)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 93 && player.Y == 57)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 57)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T6":
                            if (right == true && player.X < 53 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T7":
                            if (right == true && player.X < 53 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 53)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 53)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T8":
                            if (right == true && player.X < 133 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 93 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 93)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 93)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T9":
                            if (right == true && player.X < 133 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 93 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 133)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 133)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T10":
                            if (right == true && player.X < 93 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 53 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 53)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 53)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T11":
                            if (right == true && player.X < 93 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 53 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 93)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 93)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T12":
                            if (up == true && player.Y > 17 && player.X == 13)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 13)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T13":
                            if (up == true && player.Y > 97 && player.X == 93)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 93)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T14":
                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 133)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 133)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T15":
                            if (right == true && player.X < 253 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 133)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 133)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T16":
                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 133)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 133)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T17":
                            if (up == true && player.Y > 77 && player.X == 173)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 173)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 373 && player.Y == 77)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 173 && player.Y == 77)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T18":
                            if (up == true && player.Y > 77 && player.X == 173)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 173)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T19":
                            if (up == true && player.Y > 117 && player.X == 193)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 193)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T20":
                            if (up == true && player.Y > 117 && player.X == 193)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 193)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 253 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T21":
                            if (up == true && player.Y > 77 && player.X == 233)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 233)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 373 && player.Y == 77)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 173 && player.Y == 77)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T22":
                            if (up == true && player.Y > 77 && player.X == 233)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 233)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T23":
                            if (up == true && player.Y > 157 && player.X == 253)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 253)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 253 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T24":
                            if (up == true && player.Y > 157 && player.X == 253)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 253)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T25":
                            if (up == true && player.Y > 157 && player.X == 293)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 293)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T26":
                            if (up == true && player.Y > 157 && player.X == 293)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 293)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T27":
                            if (up == true && player.Y > 77 && player.X == 313)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 313)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 373 && player.Y == 77)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 173 && player.Y == 77)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T28":
                            if (up == true && player.Y > 77 && player.X == 313)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 313)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T29":
                            if (up == true && player.Y > 117 && player.X == 353)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 353)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T30":
                            if (up == true && player.Y > 117 && player.X == 353)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 353)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T31":
                            if (up == true && player.Y > 77 && player.X == 373)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 373)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 373 && player.Y == 77)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 173 && player.Y == 77)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T32":
                            if (up == true && player.Y > 77 && player.X == 373)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 117 && player.X == 373)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T33":
                            if (right == true && player.X < 413 && player.Y == 117)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 133 && player.Y == 117)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 413)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 413)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T34":
                            if (right == true && player.X < 413 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 293 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 413)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 413)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T35":
                            if (up == true && player.Y > 17 && player.X == 413)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 413)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T36":
                            if (up == true && player.Y > 17 && player.X == 413)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 413)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 17)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 413 && player.Y == 17)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T37":
                            if (up == true && player.Y > 17 && player.X == 453)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 57 && player.X == 453)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 17)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 413 && player.Y == 17)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T38":
                            if (up == true && player.Y > 17 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 17)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 413 && player.Y == 17)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T39":
                            if (right == true && player.X < 533 && player.Y == 57)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 453 && player.Y == 57)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 453)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 57 && player.X == 453)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T40":
                            if (right == true && player.X < 533 && player.Y == 57)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 453 && player.Y == 57)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T41":
                            if (right == true && player.X < 453 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 413 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 413)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 413)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T42":
                            if (right == true && player.X < 453 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 413 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 453)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 453)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T43":
                            if (right == true && player.X < 533 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 493 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 493)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 493)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T44":
                            if (right == true && player.X < 533 && player.Y == 97)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 493 && player.Y == 97)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 17 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T45":
                            if (right == true && player.X < 493 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 453 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 453)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 453)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T46":
                            if (right == true && player.X < 493 && player.Y == 157)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 453 && player.Y == 157)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }

                            if (up == true && player.Y > 97 && player.X == 493)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 157 && player.X == 493)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }
                            break;
                        case "T47":
                            if (up == true && player.Y > 97 && player.X == 453)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 453)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "T48":
                            if (up == true && player.Y > 17 && player.X == 533)
                            {
                                player.Y -= playerSpeed;
                                playerDirection = "up";
                            }

                            if (down == true && player.Y < 197 && player.X == 533)
                            {
                                player.Y += playerSpeed;
                                playerDirection = "down";
                            }

                            if (right == true && player.X < 533 && player.Y == 197)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 13 && player.Y == 197)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;

                        //start
                        case "start":
                            if (right == true && player.X < 293 && player.Y == 447)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 253 && player.Y == 447)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;

                        //Warp
                        case "warpL":
                            player.Location = new Point(559, 242);
                            break;
                        case "warpR":
                            player.Location = new Point(-19, 242);
                            break;
                        case "W1":
                            if (right == true && player.X < 63 && player.Y == 242)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > -20 && player.Y == 242)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                        case "W2":
                            if (right == true && player.X < 560 && player.Y == 242)
                            {
                                player.X += playerSpeed;
                                playerDirection = "right";
                            }

                            if (left == true && player.X > 483 && player.Y == 242)
                            {
                                player.X -= playerSpeed;
                                playerDirection = "left";
                            }
                            break;
                    }

                    if (smallPoint1.IntersectsWith(player))
                    {
                        smallPoint1.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint2.IntersectsWith(player))
                    {
                        smallPoint2.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint3.IntersectsWith(player))
                    {
                        smallPoint3.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint4.IntersectsWith(player))
                    {
                        smallPoint4.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint5.IntersectsWith(player))
                    {
                        smallPoint5.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint6.IntersectsWith(player))
                    {
                        smallPoint6.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint7.IntersectsWith(player))
                    {
                        smallPoint7.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint8.IntersectsWith(player))
                    {
                        smallPoint8.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint9.IntersectsWith(player))
                    {
                        smallPoint9.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint10.IntersectsWith(player))
                    {
                        smallPoint10.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint11.IntersectsWith(player))
                    {
                        smallPoint11.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint12.IntersectsWith(player))
                    {
                        smallPoint12.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint13.IntersectsWith(player))
                    {
                        smallPoint13.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint14.IntersectsWith(player))
                    {
                        smallPoint14.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint15.IntersectsWith(player))
                    {
                        smallPoint15.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint16.IntersectsWith(player))
                    {
                        smallPoint16.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint17.IntersectsWith(player))
                    {
                        smallPoint17.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint18.IntersectsWith(player))
                    {
                        smallPoint18.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint19.IntersectsWith(player))
                    {
                        smallPoint19.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint20.IntersectsWith(player))
                    {
                        smallPoint20.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint21.IntersectsWith(player))
                    {
                        smallPoint21.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint22.IntersectsWith(player))
                    {
                        smallPoint22.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint23.IntersectsWith(player))
                    {
                        smallPoint23.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint24.IntersectsWith(player))
                    {
                        smallPoint24.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint25.IntersectsWith(player))
                    {
                        smallPoint25.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint26.IntersectsWith(player))
                    {
                        smallPoint26.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint27.IntersectsWith(player))
                    {
                        smallPoint27.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint28.IntersectsWith(player))
                    {
                        smallPoint28.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint29.IntersectsWith(player))
                    {
                        smallPoint29.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint30.IntersectsWith(player))
                    {
                        smallPoint30.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint31.IntersectsWith(player))
                    {
                        smallPoint31.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint32.IntersectsWith(player))
                    {
                        smallPoint32.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint33.IntersectsWith(player))
                    {
                        smallPoint33.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint34.IntersectsWith(player))
                    {
                        smallPoint34.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint35.IntersectsWith(player))
                    {
                        smallPoint35.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint36.IntersectsWith(player))
                    {
                        smallPoint36.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint37.IntersectsWith(player))
                    {
                        smallPoint37.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint38.IntersectsWith(player))
                    {
                        smallPoint38.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint39.IntersectsWith(player))
                    {
                        smallPoint39.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint40.IntersectsWith(player))
                    {
                        smallPoint40.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint41.IntersectsWith(player))
                    {
                        smallPoint41.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint42.IntersectsWith(player))
                    {
                        smallPoint42.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint43.IntersectsWith(player))
                    {
                        smallPoint43.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint44.IntersectsWith(player))
                    {
                        smallPoint44.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint45.IntersectsWith(player))
                    {
                        smallPoint45.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint46.IntersectsWith(player))
                    {
                        smallPoint46.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint47.IntersectsWith(player))
                    {
                        smallPoint47.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint48.IntersectsWith(player))
                    {
                        smallPoint48.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint49.IntersectsWith(player))
                    {
                        smallPoint49.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint50.IntersectsWith(player))
                    {
                        smallPoint50.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint51.IntersectsWith(player))
                    {
                        smallPoint51.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint52.IntersectsWith(player))
                    {
                        smallPoint52.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint53.IntersectsWith(player))
                    {
                        smallPoint53.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint54.IntersectsWith(player))
                    {
                        smallPoint54.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint55.IntersectsWith(player))
                    {
                        smallPoint55.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint56.IntersectsWith(player))
                    {
                        smallPoint56.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint57.IntersectsWith(player))
                    {
                        smallPoint57.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint58.IntersectsWith(player))
                    {
                        smallPoint58.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint59.IntersectsWith(player))
                    {
                        smallPoint59.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint60.IntersectsWith(player))
                    {
                        smallPoint60.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint61.IntersectsWith(player))
                    {
                        smallPoint61.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint62.IntersectsWith(player))
                    {
                        smallPoint62.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint63.IntersectsWith(player))
                    {
                        smallPoint63.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint64.IntersectsWith(player))
                    {
                        smallPoint64.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint65.IntersectsWith(player))
                    {
                        smallPoint65.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint66.IntersectsWith(player))
                    {
                        smallPoint66.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint67.IntersectsWith(player))
                    {
                        smallPoint67.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint68.IntersectsWith(player))
                    {
                        smallPoint68.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint69.IntersectsWith(player))
                    {
                        smallPoint69.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint70.IntersectsWith(player))
                    {
                        smallPoint70.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint71.IntersectsWith(player))
                    {
                        smallPoint71.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint72.IntersectsWith(player))
                    {
                        smallPoint72.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint73.IntersectsWith(player))
                    {
                        smallPoint73.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint74.IntersectsWith(player))
                    {
                        smallPoint74.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint75.IntersectsWith(player))
                    {
                        smallPoint75.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint76.IntersectsWith(player))
                    {
                        smallPoint76.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint77.IntersectsWith(player))
                    {
                        smallPoint77.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint78.IntersectsWith(player))
                    {
                        smallPoint78.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint79.IntersectsWith(player))
                    {
                        smallPoint79.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint80.IntersectsWith(player))
                    {
                        smallPoint80.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint81.IntersectsWith(player))
                    {
                        smallPoint81.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint82.IntersectsWith(player))
                    {
                        smallPoint82.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint83.IntersectsWith(player))
                    {
                        smallPoint83.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint84.IntersectsWith(player))
                    {
                        smallPoint84.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint85.IntersectsWith(player))
                    {
                        smallPoint85.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint86.IntersectsWith(player))
                    {
                        smallPoint86.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint87.IntersectsWith(player))
                    {
                        smallPoint87.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint88.IntersectsWith(player))
                    {
                        smallPoint88.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint89.IntersectsWith(player))
                    {
                        smallPoint89.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint90.IntersectsWith(player))
                    {
                        smallPoint90.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint91.IntersectsWith(player))
                    {
                        smallPoint91.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint92.IntersectsWith(player))
                    {
                        smallPoint92.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint93.IntersectsWith(player))
                    {
                        smallPoint93.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint94.IntersectsWith(player))
                    {
                        smallPoint94.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint95.IntersectsWith(player))
                    {
                        smallPoint95.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint96.IntersectsWith(player))
                    {
                        smallPoint96.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint97.IntersectsWith(player))
                    {
                        smallPoint97.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint98.IntersectsWith(player))
                    {
                        smallPoint98.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint99.IntersectsWith(player))
                    {
                        smallPoint99.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint100.IntersectsWith(player))
                    {
                        smallPoint100.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint101.IntersectsWith(player))
                    {
                        smallPoint101.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint102.IntersectsWith(player))
                    {
                        smallPoint102.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint103.IntersectsWith(player))
                    {
                        smallPoint103.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint104.IntersectsWith(player))
                    {
                        smallPoint104.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint105.IntersectsWith(player))
                    {
                        smallPoint105.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint106.IntersectsWith(player))
                    {
                        smallPoint106.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint107.IntersectsWith(player))
                    {
                        smallPoint107.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint108.IntersectsWith(player))
                    {
                        smallPoint108.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint109.IntersectsWith(player))
                    {
                        smallPoint109.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint110.IntersectsWith(player))
                    {
                        smallPoint110.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint111.IntersectsWith(player))
                    {
                        smallPoint111.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint112.IntersectsWith(player))
                    {
                        smallPoint112.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint113.IntersectsWith(player))
                    {
                        smallPoint113.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint114.IntersectsWith(player))
                    {
                        smallPoint114.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint115.IntersectsWith(player))
                    {
                        smallPoint115.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint116.IntersectsWith(player))
                    {
                        smallPoint116.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint117.IntersectsWith(player))
                    {
                        smallPoint117.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint118.IntersectsWith(player))
                    {
                        smallPoint118.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint119.IntersectsWith(player))
                    {
                        smallPoint119.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint120.IntersectsWith(player))
                    {
                        smallPoint120.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint121.IntersectsWith(player))
                    {
                        smallPoint121.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint122.IntersectsWith(player))
                    {
                        smallPoint122.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint123.IntersectsWith(player))
                    {
                        smallPoint123.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint124.IntersectsWith(player))
                    {
                        smallPoint124.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint125.IntersectsWith(player))
                    {
                        smallPoint125.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint126.IntersectsWith(player))
                    {
                        smallPoint126.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint127.IntersectsWith(player))
                    {
                        smallPoint127.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint128.IntersectsWith(player))
                    {
                        smallPoint128.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint129.IntersectsWith(player))
                    {
                        smallPoint129.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint130.IntersectsWith(player))
                    {
                        smallPoint130.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint131.IntersectsWith(player))
                    {
                        smallPoint131.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint132.IntersectsWith(player))
                    {
                        smallPoint132.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint133.IntersectsWith(player))
                    {
                        smallPoint133.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint134.IntersectsWith(player))
                    {
                        smallPoint134.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint135.IntersectsWith(player))
                    {
                        smallPoint135.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint136.IntersectsWith(player))
                    {
                        smallPoint136.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint137.IntersectsWith(player))
                    {
                        smallPoint137.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint138.IntersectsWith(player))
                    {
                        smallPoint138.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint139.IntersectsWith(player))
                    {
                        smallPoint139.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint140.IntersectsWith(player))
                    {
                        smallPoint140.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint141.IntersectsWith(player))
                    {
                        smallPoint141.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint142.IntersectsWith(player))
                    {
                        smallPoint142.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint143.IntersectsWith(player))
                    {
                        smallPoint143.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint144.IntersectsWith(player))
                    {
                        smallPoint144.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint145.IntersectsWith(player))
                    {
                        smallPoint145.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint146.IntersectsWith(player))
                    {
                        smallPoint146.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint147.IntersectsWith(player))
                    {
                        smallPoint147.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint148.IntersectsWith(player))
                    {
                        smallPoint148.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint149.IntersectsWith(player))
                    {
                        smallPoint149.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint150.IntersectsWith(player))
                    {
                        smallPoint150.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint151.IntersectsWith(player))
                    {
                        smallPoint151.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint152.IntersectsWith(player))
                    {
                        smallPoint152.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint153.IntersectsWith(player))
                    {
                        smallPoint153.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint154.IntersectsWith(player))
                    {
                        smallPoint154.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint155.IntersectsWith(player))
                    {
                        smallPoint155.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint156.IntersectsWith(player))
                    {
                        smallPoint156.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint157.IntersectsWith(player))
                    {
                        smallPoint157.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint158.IntersectsWith(player))
                    {
                        smallPoint158.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint159.IntersectsWith(player))
                    {
                        smallPoint159.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint160.IntersectsWith(player))
                    {
                        smallPoint160.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint161.IntersectsWith(player))
                    {
                        smallPoint161.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint162.IntersectsWith(player))
                    {
                        smallPoint162.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint163.IntersectsWith(player))
                    {
                        smallPoint163.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint164.IntersectsWith(player))
                    {
                        smallPoint164.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint165.IntersectsWith(player))
                    {
                        smallPoint165.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint166.IntersectsWith(player))
                    {
                        smallPoint166.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint167.IntersectsWith(player))
                    {
                        smallPoint167.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint168.IntersectsWith(player))
                    {
                        smallPoint168.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint169.IntersectsWith(player))
                    {
                        smallPoint169.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint170.IntersectsWith(player))
                    {
                        smallPoint170.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint171.IntersectsWith(player))
                    {
                        smallPoint171.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint172.IntersectsWith(player))
                    {
                        smallPoint172.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint173.IntersectsWith(player))
                    {
                        smallPoint173.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint174.IntersectsWith(player))
                    {
                        smallPoint174.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint175.IntersectsWith(player))
                    {
                        smallPoint175.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint176.IntersectsWith(player))
                    {
                        smallPoint176.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint177.IntersectsWith(player))
                    {
                        smallPoint177.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint178.IntersectsWith(player))
                    {
                        smallPoint178.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint179.IntersectsWith(player))
                    {
                        smallPoint179.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint180.IntersectsWith(player))
                    {
                        smallPoint180.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint181.IntersectsWith(player))
                    {
                        smallPoint181.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint182.IntersectsWith(player))
                    {
                        smallPoint182.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint183.IntersectsWith(player))
                    {
                        smallPoint183.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint184.IntersectsWith(player))
                    {
                        smallPoint184.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint185.IntersectsWith(player))
                    {
                        smallPoint185.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint186.IntersectsWith(player))
                    {
                        smallPoint186.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint187.IntersectsWith(player))
                    {
                        smallPoint187.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint188.IntersectsWith(player))
                    {
                        smallPoint188.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint189.IntersectsWith(player))
                    {
                        smallPoint189.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint190.IntersectsWith(player))
                    {
                        smallPoint190.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint191.IntersectsWith(player))
                    {
                        smallPoint191.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint192.IntersectsWith(player))
                    {
                        smallPoint192.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint193.IntersectsWith(player))
                    {
                        smallPoint193.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint194.IntersectsWith(player))
                    {
                        smallPoint194.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint195.IntersectsWith(player))
                    {
                        smallPoint195.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint196.IntersectsWith(player))
                    {
                        smallPoint196.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint197.IntersectsWith(player))
                    {
                        smallPoint197.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint198.IntersectsWith(player))
                    {
                        smallPoint198.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint199.IntersectsWith(player))
                    {
                        smallPoint199.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint200.IntersectsWith(player))
                    {
                        smallPoint200.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint201.IntersectsWith(player))
                    {
                        smallPoint201.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint202.IntersectsWith(player))
                    {
                        smallPoint202.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint203.IntersectsWith(player))
                    {
                        smallPoint203.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint204.IntersectsWith(player))
                    {
                        smallPoint204.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint205.IntersectsWith(player))
                    {
                        smallPoint205.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint206.IntersectsWith(player))
                    {
                        smallPoint206.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint207.IntersectsWith(player))
                    {
                        smallPoint207.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint208.IntersectsWith(player))
                    {
                        smallPoint208.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint209.IntersectsWith(player))
                    {
                        smallPoint209.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint210.IntersectsWith(player))
                    {
                        smallPoint210.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint211.IntersectsWith(player))
                    {
                        smallPoint211.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint212.IntersectsWith(player))
                    {
                        smallPoint212.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint213.IntersectsWith(player))
                    {
                        smallPoint213.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint214.IntersectsWith(player))
                    {
                        smallPoint214.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint215.IntersectsWith(player))
                    {
                        smallPoint215.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint216.IntersectsWith(player))
                    {
                        smallPoint216.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint217.IntersectsWith(player))
                    {
                        smallPoint217.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint218.IntersectsWith(player))
                    {
                        smallPoint218.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint219.IntersectsWith(player))
                    {
                        smallPoint219.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint220.IntersectsWith(player))
                    {
                        smallPoint220.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint221.IntersectsWith(player))
                    {
                        smallPoint221.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint222.IntersectsWith(player))
                    {
                        smallPoint222.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint223.IntersectsWith(player))
                    {
                        smallPoint223.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint224.IntersectsWith(player))
                    {
                        smallPoint224.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint225.IntersectsWith(player))
                    {
                        smallPoint225.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint226.IntersectsWith(player))
                    {
                        smallPoint226.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint227.IntersectsWith(player))
                    {
                        smallPoint227.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint228.IntersectsWith(player))
                    {
                        smallPoint228.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint229.IntersectsWith(player))
                    {
                        smallPoint229.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint230.IntersectsWith(player))
                    {
                        smallPoint230.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint231.IntersectsWith(player))
                    {
                        smallPoint231.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint232.IntersectsWith(player))
                    {
                        smallPoint232.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint233.IntersectsWith(player))
                    {
                        smallPoint233.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint234.IntersectsWith(player))
                    {
                        smallPoint234.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint235.IntersectsWith(player))
                    {
                        smallPoint235.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint236.IntersectsWith(player))
                    {
                        smallPoint236.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint237.IntersectsWith(player))
                    {
                        smallPoint237.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint238.IntersectsWith(player))
                    {
                        smallPoint238.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint239.IntersectsWith(player))
                    {
                        smallPoint239.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint240.IntersectsWith(player))
                    {
                        smallPoint240.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint241.IntersectsWith(player))
                    {
                        smallPoint241.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint242.IntersectsWith(player))
                    {
                        smallPoint242.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint243.IntersectsWith(player))
                    {
                        smallPoint243.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint244.IntersectsWith(player))
                    {
                        smallPoint244.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint245.IntersectsWith(player))
                    {
                        smallPoint245.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint246.IntersectsWith(player))
                    {
                        smallPoint246.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint247.IntersectsWith(player))
                    {
                        smallPoint247.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint248.IntersectsWith(player))
                    {
                        smallPoint248.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint249.IntersectsWith(player))
                    {
                        smallPoint249.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint250.IntersectsWith(player))
                    {
                        smallPoint250.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint251.IntersectsWith(player))
                    {
                        smallPoint251.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint252.IntersectsWith(player))
                    {
                        smallPoint252.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint253.IntersectsWith(player))
                    {
                        smallPoint253.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint254.IntersectsWith(player))
                    {
                        smallPoint254.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint255.IntersectsWith(player))
                    {
                        smallPoint255.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint256.IntersectsWith(player))
                    {
                        smallPoint256.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint257.IntersectsWith(player))
                    {
                        smallPoint257.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint258.IntersectsWith(player))
                    {
                        smallPoint258.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint259.IntersectsWith(player))
                    {
                        smallPoint259.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint260.IntersectsWith(player))
                    {
                        smallPoint260.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint261.IntersectsWith(player))
                    {
                        smallPoint261.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint262.IntersectsWith(player))
                    {
                        smallPoint262.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint263.IntersectsWith(player))
                    {
                        smallPoint263.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint264.IntersectsWith(player))
                    {
                        smallPoint264.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint265.IntersectsWith(player))
                    {
                        smallPoint265.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint266.IntersectsWith(player))
                    {
                        smallPoint266.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint267.IntersectsWith(player))
                    {
                        smallPoint267.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint268.IntersectsWith(player))
                    {
                        smallPoint268.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint269.IntersectsWith(player))
                    {
                        smallPoint269.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint270.IntersectsWith(player))
                    {
                        smallPoint270.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint271.IntersectsWith(player))
                    {
                        smallPoint271.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint272.IntersectsWith(player))
                    {
                        smallPoint272.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint273.IntersectsWith(player))
                    {
                        smallPoint273.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint274.IntersectsWith(player))
                    {
                        smallPoint274.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint275.IntersectsWith(player))
                    {
                        smallPoint275.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint276.IntersectsWith(player))
                    {
                        smallPoint276.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint277.IntersectsWith(player))
                    {
                        smallPoint277.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint278.IntersectsWith(player))
                    {
                        smallPoint278.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint279.IntersectsWith(player))
                    {
                        smallPoint279.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint280.IntersectsWith(player))
                    {
                        smallPoint280.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint281.IntersectsWith(player))
                    {
                        smallPoint281.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint282.IntersectsWith(player))
                    {
                        smallPoint282.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint283.IntersectsWith(player))
                    {
                        smallPoint283.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint284.IntersectsWith(player))
                    {
                        smallPoint284.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint285.IntersectsWith(player))
                    {
                        smallPoint285.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint286.IntersectsWith(player))
                    {
                        smallPoint286.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint287.IntersectsWith(player))
                    {
                        smallPoint287.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint288.IntersectsWith(player))
                    {
                        smallPoint288.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint289.IntersectsWith(player))
                    {
                        smallPoint289.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint290.IntersectsWith(player))
                    {
                        smallPoint290.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint291.IntersectsWith(player))
                    {
                        smallPoint291.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint292.IntersectsWith(player))
                    {
                        smallPoint292.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint293.IntersectsWith(player))
                    {
                        smallPoint293.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint294.IntersectsWith(player))
                    {
                        smallPoint294.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint295.IntersectsWith(player))
                    {
                        smallPoint295.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint296.IntersectsWith(player))
                    {
                        smallPoint296.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint297.IntersectsWith(player))
                    {
                        smallPoint297.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint298.IntersectsWith(player))
                    {
                        smallPoint298.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint299.IntersectsWith(player))
                    {
                        smallPoint299.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint300.IntersectsWith(player))
                    {
                        smallPoint300.Location = new Point(-10, -10);
                        pointSound.Play();
                    }
                    else if (smallPoint301.IntersectsWith(player))
                    {
                        smallPoint301.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint302.IntersectsWith(player))
                    {
                        smallPoint302.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint303.IntersectsWith(player))
                    {
                        smallPoint303.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint304.IntersectsWith(player))
                    {
                        smallPoint304.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint305.IntersectsWith(player))
                    {
                        smallPoint305.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint306.IntersectsWith(player))
                    {
                        smallPoint306.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint307.IntersectsWith(player))
                    {
                        smallPoint307.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint308.IntersectsWith(player))
                    {
                        smallPoint308.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint309.IntersectsWith(player))
                    {
                        smallPoint309.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint310.IntersectsWith(player))
                    {
                        smallPoint310.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint311.IntersectsWith(player))
                    {
                        smallPoint311.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint312.IntersectsWith(player))
                    {
                        smallPoint312.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint313.IntersectsWith(player))
                    {
                        smallPoint313.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint314.IntersectsWith(player))
                    {
                        smallPoint314.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint315.IntersectsWith(player))
                    {
                        smallPoint315.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint316.IntersectsWith(player))
                    {
                        smallPoint316.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint317.IntersectsWith(player))
                    {
                        smallPoint317.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint318.IntersectsWith(player))
                    {
                        smallPoint318.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint319.IntersectsWith(player))
                    {
                        smallPoint319.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint320.IntersectsWith(player))
                    {
                        smallPoint320.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint321.IntersectsWith(player))
                    {
                        smallPoint321.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint322.IntersectsWith(player))
                    {
                        smallPoint322.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint323.IntersectsWith(player))
                    {
                        smallPoint323.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint324.IntersectsWith(player))
                    {
                        smallPoint324.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint325.IntersectsWith(player))
                    {
                        smallPoint325.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint326.IntersectsWith(player))
                    {
                        smallPoint326.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint327.IntersectsWith(player))
                    {
                        smallPoint327.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint328.IntersectsWith(player))
                    {
                        smallPoint328.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint329.IntersectsWith(player))
                    {
                        smallPoint329.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint330.IntersectsWith(player))
                    {
                        smallPoint330.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint331.IntersectsWith(player))
                    {
                        smallPoint331.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint332.IntersectsWith(player))
                    {
                        smallPoint332.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint333.IntersectsWith(player))
                    {
                        smallPoint333.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint334.IntersectsWith(player))
                    {
                        smallPoint334.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint335.IntersectsWith(player))
                    {
                        smallPoint335.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint336.IntersectsWith(player))
                    {
                        smallPoint336.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint337.IntersectsWith(player))
                    {
                        smallPoint337.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint338.IntersectsWith(player))
                    {
                        smallPoint338.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint339.IntersectsWith(player))
                    {
                        smallPoint339.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint340.IntersectsWith(player))
                    {
                        smallPoint340.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint341.IntersectsWith(player))
                    {
                        smallPoint341.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint342.IntersectsWith(player))
                    {
                        smallPoint342.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint343.IntersectsWith(player))
                    {
                        smallPoint343.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint344.IntersectsWith(player))
                    {
                        smallPoint344.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint345.IntersectsWith(player))
                    {
                        smallPoint345.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint346.IntersectsWith(player))
                    {
                        smallPoint346.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint347.IntersectsWith(player))
                    {
                        smallPoint347.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint348.IntersectsWith(player))
                    {
                        smallPoint348.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint349.IntersectsWith(player))
                    {
                        smallPoint349.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }
                    else if (smallPoint350.IntersectsWith(player))
                    {
                        smallPoint350.Location = new Point(-10, -10);
                        pointSound.Play();
                        point++;
                    }

                    //Intersects with big points
                    if (bigPoint1.IntersectsWith(player))
                    {
                        bigPoint1.Location = new Point(-20, -20);
                        point += 5;
                        powerup = "true";
                        powerupTimer.Enabled = true;
                    }
                    else if (bigPoint2.IntersectsWith(player))
                    {
                        bigPoint2.Location = new Point(-20, -20);
                        point += 5;
                        powerup = "true";
                        powerupTimer.Enabled = true;
                    }
                    else if (bigPoint3.IntersectsWith(player))
                    {
                        bigPoint3.Location = new Point(-20, -20);
                        point += 5;
                        powerup = "true";
                        powerupTimer.Enabled = true;
                    }
                    else if (bigPoint4.IntersectsWith(player))
                    {
                        bigPoint4.Location = new Point(-10, -10);
                        point += 5;
                        powerup = "true";
                        powerupTimer.Enabled = true;
                    }
                    else if (bigPoint5.IntersectsWith(player))
                    {
                        bigPoint5.Location = new Point(-20, -20);
                        point += 5;
                        powerup = "true";
                        powerupTimer.Enabled = true;
                    }
                    else if (bigPoint6.IntersectsWith(player))
                    {
                        bigPoint6.Location = new Point(-20, -20);
                        point += 5;
                        powerup = "true";
                        powerupTimer.Enabled = true;
                    }

                    //Intersects with enemies
                    Rectangle enemy1 = new Rectangle(enemy1X, enemy1Y, 16, 16);
                    Rectangle enemy2 = new Rectangle(enemy2X, enemy2Y, 16, 16);
                    Rectangle enemy3 = new Rectangle(enemy3X, enemy3Y, 16, 16);
                    Rectangle enemy4 = new Rectangle(enemy4X, enemy4Y, 16, 16);
                    Rectangle enemy5 = new Rectangle(enemy5X, enemy5Y, 16, 16);
                    Rectangle enemy6 = new Rectangle(enemy6X, enemy6Y, 16, 16);
                    Rectangle enemy7 = new Rectangle(enemy7X, enemy7Y, 16, 16);
                    Rectangle enemy8 = new Rectangle(enemy8X, enemy8Y, 16, 16);
                    if (player.IntersectsWith(enemy1))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy1Location = "";
                            enemy1X = -30;
                            enemy1Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy2))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy2Location = "";
                            enemy2X = -30;
                            enemy2Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy3))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy3Location = "";
                            enemy3X = -30;
                            enemy3Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy4))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy4Location = "";
                            enemy4X = -30;
                            enemy4Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy5))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy5Location = "";
                            enemy5X = -30;
                            enemy5Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy6))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy6Location = "";
                            enemy6X = -30;
                            enemy6Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy7))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy7Location = "";
                            enemy7X = -30;
                            enemy7Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    else if (player.IntersectsWith(enemy8))
                    {
                        gameoverSound.Play();
                        if (powerup == "true")
                        {
                            eatEnemiesPoint++;
                            enemy8Location = "";
                            enemy8X = -30;
                            enemy8Y = -30;
                            eatEnemiesSound.Play();
                        }
                        else
                        {
                            if (life == 1)
                            {
                                life = 0;
                                situation = "dead";
                            }
                            else
                            {
                                situation = "gameover";
                            }
                        }
                    }
                    int score = point * 10;
                    scoreLabel.Text = $"SCORE: {score}";
                    eliminateLabel.Text = $"ELIMINATE:    x{eatEnemiesPoint}";

                    //Game Clear
                    if (point == 371)
                    {
                        clearSound.Play();
                        situation = "gameclear";
                    }

                    break;

                case "gameover":
                    menuLabel.Visible = false;
                    score = point * 10;
                    playerTimer.Enabled = false;
                    gameoverTimer.Enabled = true;
                    scoreLabel.Text = $"SCORE: {score}";
                    eliminateLabel.Text = $"ELIMINATE:    x{eatEnemiesPoint}";
                    break;

                case "dead":
                    gameoverCount++;
                    eliminateLabel.Visible = false;
                    scoreLabel.Visible = false;
                    pictureBox1.Visible = false;
                    gameendPic.Visible = true;
                    enemy1Pic.Visible = false;
                    enemy2Pic.Visible = false;
                    enemy3Pic.Visible = false;
                    enemy4Pic.Visible = false;
                    enemy5Pic.Visible = false;
                    enemy6Pic.Visible = false;
                    enemy7Pic.Visible = false;
                    enemy8Pic.Visible = false;
                    gameendPic.BackgroundImage = Properties.Resources.gameoverPic;
                    wordPen = new Pen(Color.Transparent, 3);
                    edgePen = new Pen(Color.Transparent, 3);
                    pointBrush = new SolidBrush(Color.Transparent);
                    bigpointBrush = new SolidBrush(Color.Transparent);

                    score = point * 10;
                    scoreLabel.Text = $"SCORE: {score}";
                    eliminateLabel.Text = $"ELIMINATE:    x{eatEnemiesPoint}";
                    break;

                case "gameclear":
                    gameclearCount++;
                    enemyTimer.Enabled = false;
                    gameendPic.Visible = true;
                    gameendPic.BackgroundImage = Properties.Resources.gameClearPic;
                    if (gameclearCount <= 50)
                    {
                        wordPen = new Pen(Color.White, 3);
                        edgePen = new Pen(Color.White, 3);
                    }
                    else if (gameclearCount <= 100)
                    {
                        wordPen = new Pen(Color.FromArgb(53, 40, 220), 3);
                        edgePen = new Pen(Color.FromArgb(35, 35, 202), 3);
                    }
                    else if (gameclearCount <= 150)
                    {
                        wordPen = new Pen(Color.White, 3);
                        edgePen = new Pen(Color.White, 3);
                    }
                    else if (gameclearCount <= 200)
                    {
                        wordPen = new Pen(Color.FromArgb(53, 40, 220), 3);
                        edgePen = new Pen(Color.FromArgb(35, 35, 202), 3);
                    }
                    else if (gameclearCount <= 250)
                    {
                        wordPen = new Pen(Color.White, 3);
                        edgePen = new Pen(Color.White, 3);
                    }
                    else if (gameclearCount <= 300)
                    {
                        wordPen = new Pen(Color.FromArgb(53, 40, 220), 3);
                        edgePen = new Pen(Color.FromArgb(35, 35, 202), 3);
                        if (gameclearCount == 300)
                        {
                            situation = "reset";
                        }
                    }
                    score = point * 10;
                    scoreLabel.Text = $"SCORE: {score}";
                    eliminateLabel.Text = $"ELIMINATE:    x{eatEnemiesPoint}";
                    break;

                case "reset":
                    enemyTimer.Enabled = true;
                    wordPen = new Pen(Color.FromArgb(53, 40, 220), 3);
                    edgePen = new Pen(Color.FromArgb(35, 35, 202), 3);
                    pointBrush = new SolidBrush(Color.FromArgb(255, 207, 185));
                    bigpointBrush = new SolidBrush(Color.FromArgb(255, 238, 231));
                    yellowBrush = new SolidBrush(Color.FromArgb(253, 229, 5));
                    menuPic.Visible = true;
                    menuLabel.Text = "Press “SPACE” to start the game";
                    eliminateLabel.Visible = true;
                    scoreLabel.Visible = true;
                    pictureBox1.Visible = true;
                    gameendPic.Visible = false;
                    player.Location = new Point(273, 447);
                    life1.Location = new Point(530, 470);
                    life2.Location = new Point(510, 470);
                    life3.Location = new Point(490, 470);
                    life = 3;
                    gameclearCount = 0;
                    point = 0;
                    eatEnemiesPoint = 0;
                    powerupCount = 0;
                    playerSpeed = 1;
                    playerAngle1 = 0;
                    playerAngle2 = 360;
                    lifecheck = "No";
                    playerDirection = "";
                    playerLocation = "";
                    powerup = "false";
                    up = false;
                    down = false;
                    right = false;
                    left = false;
                    space = false;
                    enemy1X = 93;
                    enemy1Y = 57;
                    enemy2X = 233;
                    enemy2Y = 77;
                    enemy3X = 313;
                    enemy3Y = 77;
                    enemy4X = 453;
                    enemy4Y = 57;
                    enemy5X = 63;
                    enemy5Y = 242;
                    enemy6X = 483;
                    enemy6Y = 242;
                    enemy7X = 113;
                    enemy7Y = 367;
                    enemy8X = 433;
                    enemy8Y = 367;
                    enemySpeed = 1;
                    enemy1Location = "T5";
                    enemy2Location = "T21";
                    enemy3Location = "T27";
                    enemy4Location = "T39";
                    enemy5Location = "M15";
                    enemy6Location = "M17";
                    enemy7Location = "B19";
                    enemy8Location = "B28";
                    enemy1Pic.BackgroundImage = null;
                    enemy2Pic.BackgroundImage = null;
                    enemy3Pic.BackgroundImage = null;
                    enemy4Pic.BackgroundImage = null;
                    enemy5Pic.BackgroundImage = null;
                    enemy6Pic.BackgroundImage = null;
                    enemy7Pic.BackgroundImage = null;
                    enemy8Pic.BackgroundImage = null;
                    smallPoint1.Location = new Point(19, 23);
                    smallPoint2.Location = new Point(39, 23);
                    smallPoint3.Location = new Point(59, 23);
                    smallPoint4.Location = new Point(79, 23);
                    smallPoint5.Location = new Point(99, 23);
                    smallPoint6.Location = new Point(119, 23);
                    smallPoint7.Location = new Point(139, 23);
                    smallPoint8.Location = new Point(19, 43);
                    smallPoint9.Location = new Point(19, 63);
                    smallPoint10.Location = new Point(19, 83);
                    smallPoint11.Location = new Point(19, 103);
                    smallPoint12.Location = new Point(19, 123);
                    smallPoint13.Location = new Point(19, 143);
                    smallPoint14.Location = new Point(19, 163);
                    smallPoint15.Location = new Point(19, 183);
                    smallPoint16.Location = new Point(19, 203);
                    smallPoint17.Location = new Point(139, 43);
                    smallPoint18.Location = new Point(139, 63);
                    smallPoint19.Location = new Point(139, 83);
                    smallPoint20.Location = new Point(139, 103);
                    smallPoint21.Location = new Point(139, 123);
                    smallPoint22.Location = new Point(139, 143);
                    smallPoint23.Location = new Point(139, 163);
                    smallPoint24.Location = new Point(139, 183);
                    smallPoint25.Location = new Point(139, 203);
                    smallPoint26.Location = new Point(99, 43);
                    smallPoint27.Location = new Point(39, 63);
                    smallPoint28.Location = new Point(59, 63);
                    smallPoint29.Location = new Point(79, 63);
                    smallPoint30.Location = new Point(39, 103);
                    smallPoint31.Location = new Point(59, 103);
                    smallPoint32.Location = new Point(59, 123);
                    smallPoint33.Location = new Point(59, 143);
                    smallPoint34.Location = new Point(59, 163);
                    smallPoint35.Location = new Point(79, 163);
                    smallPoint36.Location = new Point(99, 163);
                    smallPoint37.Location = new Point(99, 103);
                    smallPoint38.Location = new Point(119, 103);
                    smallPoint39.Location = new Point(99, 123);
                    smallPoint40.Location = new Point(99, 143);
                    smallPoint41.Location = new Point(99, 163);
                    smallPoint42.Location = new Point(99, 183);
                    smallPoint43.Location = new Point(39, 203);
                    smallPoint44.Location = new Point(59, 203);
                    smallPoint45.Location = new Point(79, 203);
                    smallPoint46.Location = new Point(99, 203);
                    smallPoint47.Location = new Point(119, 203);
                    smallPoint48.Location = new Point(159, 203);
                    smallPoint49.Location = new Point(179, 203);
                    smallPoint50.Location = new Point(199, 203);
                    smallPoint51.Location = new Point(219, 203);
                    smallPoint52.Location = new Point(239, 203);
                    smallPoint53.Location = new Point(259, 203);
                    smallPoint54.Location = new Point(279, 203);
                    smallPoint55.Location = new Point(299, 203);
                    smallPoint56.Location = new Point(319, 203);
                    smallPoint57.Location = new Point(339, 203);
                    smallPoint58.Location = new Point(359, 203);
                    smallPoint59.Location = new Point(379, 203);
                    smallPoint60.Location = new Point(399, 203);
                    smallPoint61.Location = new Point(419, 203);
                    smallPoint62.Location = new Point(439, 203);
                    smallPoint63.Location = new Point(459, 203);
                    smallPoint64.Location = new Point(479, 203);
                    smallPoint65.Location = new Point(499, 203);
                    smallPoint66.Location = new Point(519, 203);
                    smallPoint67.Location = new Point(179, 83);
                    smallPoint68.Location = new Point(179, 103);
                    smallPoint69.Location = new Point(179, 123);
                    smallPoint70.Location = new Point(199, 83);
                    smallPoint71.Location = new Point(219, 83);
                    smallPoint72.Location = new Point(159, 123);
                    smallPoint73.Location = new Point(239, 83);
                    smallPoint74.Location = new Point(259, 83);
                    smallPoint75.Location = new Point(279, 83);
                    smallPoint76.Location = new Point(299, 83);
                    smallPoint77.Location = new Point(319, 83);
                    smallPoint78.Location = new Point(339, 83);
                    smallPoint79.Location = new Point(359, 83);
                    smallPoint80.Location = new Point(379, 83);
                    smallPoint81.Location = new Point(319, 103);
                    smallPoint82.Location = new Point(239, 103);
                    smallPoint83.Location = new Point(379, 103);
                    smallPoint84.Location = new Point(199, 123);
                    smallPoint85.Location = new Point(219, 123);
                    smallPoint86.Location = new Point(239, 123);
                    smallPoint87.Location = new Point(259, 123);
                    smallPoint88.Location = new Point(279, 123);
                    smallPoint89.Location = new Point(299, 123);
                    smallPoint90.Location = new Point(319, 123);
                    smallPoint91.Location = new Point(339, 123);
                    smallPoint92.Location = new Point(359, 123);
                    smallPoint93.Location = new Point(379, 123);
                    smallPoint94.Location = new Point(399, 123);
                    smallPoint95.Location = new Point(199, 143);
                    smallPoint96.Location = new Point(359, 143);
                    smallPoint97.Location = new Point(159, 163);
                    smallPoint98.Location = new Point(179, 163);
                    smallPoint99.Location = new Point(199, 163);
                    smallPoint100.Location = new Point(219, 163);
                    smallPoint101 = new Rectangle(239, 163, 5, 5);
                    smallPoint102 = new Rectangle(259, 163, 5, 5);
                    smallPoint103 = new Rectangle(299, 163, 5, 5);
                    smallPoint104 = new Rectangle(319, 163, 5, 5);
                    smallPoint105 = new Rectangle(339, 163, 5, 5);
                    smallPoint106 = new Rectangle(359, 163, 5, 5);
                    smallPoint107 = new Rectangle(379, 163, 5, 5);
                    smallPoint108 = new Rectangle(399, 163, 5, 5);
                    smallPoint109 = new Rectangle(259, 183, 5, 5);
                    smallPoint110 = new Rectangle(299, 183, 5, 5);
                    smallPoint111 = new Rectangle(419, 23, 5, 5);
                    smallPoint112 = new Rectangle(419, 43, 5, 5);
                    smallPoint113 = new Rectangle(419, 63, 5, 5);
                    smallPoint114 = new Rectangle(419, 83, 5, 5);
                    smallPoint115 = new Rectangle(419, 103, 5, 5);
                    smallPoint116 = new Rectangle(419, 123, 5, 5);
                    smallPoint117 = new Rectangle(419, 143, 5, 5);
                    smallPoint118 = new Rectangle(419, 163, 5, 5);
                    smallPoint119 = new Rectangle(419, 183, 5, 5);
                    smallPoint120 = new Rectangle(439, 23, 5, 5);
                    smallPoint121 = new Rectangle(459, 23, 5, 5);
                    smallPoint122 = new Rectangle(479, 23, 5, 5);
                    smallPoint123 = new Rectangle(499, 23, 5, 5);
                    smallPoint124 = new Rectangle(519, 23, 5, 5);
                    smallPoint125 = new Rectangle(539, 23, 5, 5);
                    smallPoint126 = new Rectangle(539, 43, 5, 5);
                    smallPoint127 = new Rectangle(539, 63, 5, 5);
                    smallPoint128 = new Rectangle(539, 83, 5, 5);
                    smallPoint129 = new Rectangle(539, 103, 5, 5);
                    smallPoint130 = new Rectangle(539, 123, 5, 5);
                    smallPoint131 = new Rectangle(539, 143, 5, 5);
                    smallPoint132 = new Rectangle(539, 163, 5, 5);
                    smallPoint133 = new Rectangle(539, 183, 5, 5);
                    smallPoint134 = new Rectangle(539, 203, 5, 5);
                    smallPoint135 = new Rectangle(459, 43, 5, 5);
                    smallPoint136 = new Rectangle(129, 218, 5, 5);
                    smallPoint137 = new Rectangle(479, 63, 5, 5);
                    smallPoint138 = new Rectangle(499, 63, 5, 5);
                    smallPoint139 = new Rectangle(519, 63, 5, 5);
                    smallPoint140 = new Rectangle(439, 103, 5, 5);
                    smallPoint141 = new Rectangle(459, 103, 5, 5);
                    smallPoint142 = new Rectangle(459, 123, 5, 5);
                    smallPoint143 = new Rectangle(459, 143, 5, 5);
                    smallPoint144 = new Rectangle(459, 163, 5, 5);
                    smallPoint145 = new Rectangle(459, 183, 5, 5);
                    smallPoint146 = new Rectangle(499, 103, 5, 5);
                    smallPoint147 = new Rectangle(499, 123, 5, 5);
                    smallPoint148 = new Rectangle(499, 143, 5, 5);
                    smallPoint149 = new Rectangle(499, 163, 5, 5);
                    smallPoint150 = new Rectangle(479, 163, 5, 5);
                    smallPoint151 = new Rectangle(519, 103, 5, 5);
                    smallPoint152 = new Rectangle(69, 218, 5, 5);
                    smallPoint153 = new Rectangle(69, 238, 5, 5);
                    smallPoint154 = new Rectangle(69, 258, 5, 5);
                    smallPoint155 = new Rectangle(69, 278, 5, 5);
                    smallPoint156 = new Rectangle(84, 263, 5, 5);
                    smallPoint157 = new Rectangle(99, 263, 5, 5);
                    smallPoint158 = new Rectangle(99, 233, 5, 5);
                    smallPoint159 = new Rectangle(114, 233, 5, 5);
                    smallPoint160 = new Rectangle(129, 238, 5, 5);
                    smallPoint161 = new Rectangle(129, 258, 5, 5);
                    smallPoint162 = new Rectangle(129, 278, 5, 5);
                    smallPoint163 = new Rectangle(189, 218, 5, 5);
                    smallPoint164 = new Rectangle(189, 238, 5, 5);
                    smallPoint165 = new Rectangle(189, 258, 5, 5);
                    smallPoint166 = new Rectangle(189, 278, 5, 5);
                    smallPoint167 = new Rectangle(219, 218, 5, 5);
                    smallPoint168 = new Rectangle(219, 238, 5, 5);
                    smallPoint169 = new Rectangle(249, 218, 5, 5);
                    smallPoint170 = new Rectangle(249, 238, 5, 5);
                    smallPoint171 = new Rectangle(249, 258, 5, 5);
                    smallPoint172 = new Rectangle(249, 278, 5, 5);
                    smallPoint173 = new Rectangle(264, 263, 5, 5);
                    smallPoint174 = new Rectangle(279, 233, 5, 5);
                    smallPoint175 = new Rectangle(279, 263, 5, 5);
                    smallPoint176 = new Rectangle(294, 233, 5, 5);
                    smallPoint177 = new Rectangle(309, 218, 5, 5);
                    smallPoint178 = new Rectangle(309, 238, 5, 5);
                    smallPoint179 = new Rectangle(309, 258, 5, 5);
                    smallPoint180 = new Rectangle(309, 278, 5, 5);
                    smallPoint181 = new Rectangle(339, 218, 5, 5);
                    smallPoint182 = new Rectangle(339, 238, 5, 5);
                    smallPoint183 = new Rectangle(399, 223, 5, 5);
                    smallPoint184 = new Rectangle(369, 218, 5, 5);
                    smallPoint185 = new Rectangle(369, 238, 5, 5);
                    smallPoint186 = new Rectangle(369, 258, 5, 5);
                    smallPoint187 = new Rectangle(369, 278, 5, 5);
                    smallPoint188 = new Rectangle(399, 273, 5, 5);
                    smallPoint189 = new Rectangle(429, 218, 5, 5);
                    smallPoint190 = new Rectangle(429, 238, 5, 5);
                    smallPoint191 = new Rectangle(429, 258, 5, 5);
                    smallPoint192 = new Rectangle(429, 278, 5, 5);
                    smallPoint193 = new Rectangle(489, 218, 5, 5);
                    smallPoint194 = new Rectangle(489, 238, 5, 5);
                    smallPoint195 = new Rectangle(489, 258, 5, 5);
                    smallPoint196 = new Rectangle(489, 278, 5, 5);
                    smallPoint197 = new Rectangle(459, 233, 5, 5);
                    smallPoint198 = new Rectangle(459, 263, 5, 5);
                    smallPoint199 = new Rectangle(474, 233, 5, 5);
                    smallPoint200 = new Rectangle(474, 263, 5, 5);
                    smallPoint201 = new Rectangle(19, 293, 5, 5);
                    smallPoint202 = new Rectangle(39, 293, 5, 5);
                    smallPoint203 = new Rectangle(59, 293, 5, 5);
                    smallPoint204 = new Rectangle(79, 293, 5, 5);
                    smallPoint205 = new Rectangle(99, 293, 5, 5);
                    smallPoint206 = new Rectangle(119, 293, 5, 5);
                    smallPoint207 = new Rectangle(139, 293, 5, 5);
                    smallPoint208 = new Rectangle(159, 293, 5, 5);
                    smallPoint209 = new Rectangle(179, 293, 5, 5);
                    smallPoint210 = new Rectangle(199, 293, 5, 5);
                    smallPoint211 = new Rectangle(219, 293, 5, 5);
                    smallPoint212 = new Rectangle(239, 293, 5, 5);
                    smallPoint213 = new Rectangle(259, 293, 5, 5);
                    smallPoint214 = new Rectangle(279, 293, 5, 5);
                    smallPoint215 = new Rectangle(299, 293, 5, 5);
                    smallPoint216 = new Rectangle(319, 293, 5, 5);
                    smallPoint217 = new Rectangle(339, 293, 5, 5);
                    smallPoint218 = new Rectangle(359, 293, 5, 5);
                    smallPoint219 = new Rectangle(379, 293, 5, 5);
                    smallPoint220 = new Rectangle(399, 293, 5, 5);
                    smallPoint221 = new Rectangle(419, 293, 5, 5);
                    smallPoint222 = new Rectangle(439, 293, 5, 5);
                    smallPoint223 = new Rectangle(459, 293, 5, 5);
                    smallPoint224 = new Rectangle(479, 293, 5, 5);
                    smallPoint225 = new Rectangle(499, 293, 5, 5);
                    smallPoint226 = new Rectangle(519, 293, 5, 5);
                    smallPoint227 = new Rectangle(539, 293, 5, 5);
                    smallPoint228 = new Rectangle(19, 313, 5, 5);
                    smallPoint229 = new Rectangle(119, 313, 5, 5);
                    smallPoint230 = new Rectangle(279, 313, 5, 5);
                    smallPoint231 = new Rectangle(439, 313, 5, 5);
                    smallPoint232 = new Rectangle(539, 313, 5, 5);
                    smallPoint233 = new Rectangle(19, 333, 5, 5);
                    smallPoint234 = new Rectangle(39, 333, 5, 5);
                    smallPoint235 = new Rectangle(59, 333, 5, 5);
                    smallPoint236 = new Rectangle(119, 333, 5, 5);
                    smallPoint237 = new Rectangle(139, 333, 5, 5);
                    smallPoint238 = new Rectangle(159, 333, 5, 5);
                    smallPoint239 = new Rectangle(199, 333, 5, 5);
                    smallPoint240 = new Rectangle(219, 333, 5, 5);
                    smallPoint241 = new Rectangle(239, 333, 5, 5);
                    smallPoint242 = new Rectangle(259, 333, 5, 5);
                    smallPoint243 = new Rectangle(299, 333, 5, 5);
                    smallPoint244 = new Rectangle(319, 333, 5, 5);
                    smallPoint245 = new Rectangle(339, 333, 5, 5);
                    smallPoint246 = new Rectangle(359, 333, 5, 5);
                    smallPoint247 = new Rectangle(399, 333, 5, 5);
                    smallPoint248 = new Rectangle(419, 333, 5, 5);
                    smallPoint249 = new Rectangle(439, 333, 5, 5);
                    smallPoint250 = new Rectangle(479, 333, 5, 5);
                    smallPoint251 = new Rectangle(499, 333, 5, 5);
                    smallPoint252 = new Rectangle(519, 333, 5, 5);
                    smallPoint253 = new Rectangle(539, 333, 5, 5);
                    smallPoint254 = new Rectangle(79, 333, 5, 5);
                    smallPoint255 = new Rectangle(279, 333, 5, 5);
                    smallPoint256 = new Rectangle(79, 353, 5, 5);
                    smallPoint257 = new Rectangle(119, 353, 5, 5);
                    smallPoint258 = new Rectangle(159, 353, 5, 5);
                    smallPoint259 = new Rectangle(199, 353, 5, 5);
                    smallPoint260 = new Rectangle(359, 353, 5, 5);
                    smallPoint261 = new Rectangle(399, 353, 5, 5);
                    smallPoint262 = new Rectangle(439, 353, 5, 5);
                    smallPoint263 = new Rectangle(479, 353, 5, 5);
                    smallPoint264 = new Rectangle(19, 373, 5, 5);
                    smallPoint265 = new Rectangle(39, 373, 5, 5);
                    smallPoint266 = new Rectangle(59, 373, 5, 5);
                    smallPoint267 = new Rectangle(79, 373, 5, 5);
                    smallPoint268 = new Rectangle(99, 373, 5, 5);
                    smallPoint269 = new Rectangle(159, 373, 5, 5);
                    smallPoint270 = new Rectangle(179, 373, 5, 5);
                    smallPoint271 = new Rectangle(199, 373, 5, 5);
                    smallPoint272 = new Rectangle(219, 373, 5, 5);
                    smallPoint273 = new Rectangle(239, 373, 5, 5);
                    smallPoint274 = new Rectangle(259, 373, 5, 5);
                    smallPoint275 = new Rectangle(279, 373, 5, 5);
                    smallPoint276 = new Rectangle(299, 373, 5, 5);
                    smallPoint277 = new Rectangle(319, 373, 5, 5);
                    smallPoint278 = new Rectangle(339, 373, 5, 5);
                    smallPoint279 = new Rectangle(359, 373, 5, 5);
                    smallPoint280 = new Rectangle(379, 373, 5, 5);
                    smallPoint281 = new Rectangle(399, 373, 5, 5);
                    smallPoint282 = new Rectangle(19, 393, 5, 5);
                    smallPoint283 = new Rectangle(459, 373, 5, 5);
                    smallPoint284 = new Rectangle(479, 373, 5, 5);
                    smallPoint285 = new Rectangle(499, 373, 5, 5);
                    smallPoint286 = new Rectangle(519, 373, 5, 5);
                    smallPoint287 = new Rectangle(539, 373, 5, 5);
                    smallPoint288 = new Rectangle(19, 413, 5, 5);
                    smallPoint289 = new Rectangle(179, 393, 5, 5);
                    smallPoint290 = new Rectangle(219, 393, 5, 5);
                    smallPoint291 = new Rectangle(339, 393, 5, 5);
                    smallPoint292 = new Rectangle(379, 393, 5, 5);
                    smallPoint293 = new Rectangle(539, 393, 5, 5);
                    smallPoint294 = new Rectangle(39, 413, 5, 5);
                    smallPoint295 = new Rectangle(59, 413, 5, 5);
                    smallPoint296 = new Rectangle(79, 413, 5, 5);
                    smallPoint297 = new Rectangle(99, 413, 5, 5);
                    smallPoint298 = new Rectangle(119, 413, 5, 5);
                    smallPoint299 = new Rectangle(139, 413, 5, 5);
                    smallPoint300 = new Rectangle(159, 413, 5, 5);
                    smallPoint301 = new Rectangle(179, 413, 5, 5);
                    smallPoint302 = new Rectangle(199, 413, 5, 5);
                    smallPoint303 = new Rectangle(219, 413, 5, 5);
                    smallPoint304 = new Rectangle(239, 413, 5, 5);
                    smallPoint305 = new Rectangle(259, 413, 5, 5);
                    smallPoint306 = new Rectangle(299, 413, 5, 5);
                    smallPoint307 = new Rectangle(319, 413, 5, 5);
                    smallPoint308 = new Rectangle(339, 413, 5, 5);
                    smallPoint309 = new Rectangle(359, 413, 5, 5);
                    smallPoint310 = new Rectangle(379, 413, 5, 5);
                    smallPoint311 = new Rectangle(399, 413, 5, 5);
                    smallPoint312 = new Rectangle(419, 413, 5, 5);
                    smallPoint313 = new Rectangle(439, 413, 5, 5);
                    smallPoint314 = new Rectangle(459, 413, 5, 5);
                    smallPoint315 = new Rectangle(479, 413, 5, 5);
                    smallPoint316 = new Rectangle(499, 413, 5, 5);
                    smallPoint317 = new Rectangle(519, 413, 5, 5);
                    smallPoint318 = new Rectangle(539, 413, 5, 5);
                    smallPoint319 = new Rectangle(19, 433, 5, 5);
                    smallPoint320 = new Rectangle(79, 433, 5, 5);
                    smallPoint321 = new Rectangle(219, 433, 5, 5);
                    smallPoint323 = new Rectangle(259, 433, 5, 5);
                    smallPoint324 = new Rectangle(299, 433, 5, 5);
                    smallPoint325 = new Rectangle(339, 433, 5, 5);
                    smallPoint326 = new Rectangle(479, 433, 5, 5);
                    smallPoint327 = new Rectangle(539, 433, 5, 5);
                    smallPoint328 = new Rectangle(19, 453, 5, 5);
                    smallPoint329 = new Rectangle(39, 453, 5, 5);
                    smallPoint330 = new Rectangle(59, 453, 5, 5);
                    smallPoint331 = new Rectangle(79, 453, 5, 5);
                    smallPoint332 = new Rectangle(99, 453, 5, 5);
                    smallPoint333 = new Rectangle(119, 453, 5, 5);
                    smallPoint334 = new Rectangle(139, 453, 5, 5);
                    smallPoint335 = new Rectangle(159, 453, 5, 5);
                    smallPoint336 = new Rectangle(179, 453, 5, 5);
                    smallPoint337 = new Rectangle(199, 453, 5, 5);
                    smallPoint338 = new Rectangle(219, 453, 5, 5);
                    smallPoint339 = new Rectangle(259, 453, 5, 5);
                    smallPoint340 = new Rectangle(299, 453, 5, 5);
                    smallPoint341 = new Rectangle(339, 453, 5, 5);
                    smallPoint342 = new Rectangle(359, 453, 5, 5);
                    smallPoint343 = new Rectangle(379, 453, 5, 5);
                    smallPoint344 = new Rectangle(399, 453, 5, 5);
                    smallPoint345 = new Rectangle(419, 453, 5, 5);
                    smallPoint346 = new Rectangle(439, 453, 5, 5);
                    smallPoint347 = new Rectangle(459, 453, 5, 5);
                    smallPoint348 = new Rectangle(479, 453, 5, 5);
                    smallPoint349 = new Rectangle(499, 453, 5, 5);
                    smallPoint350 = new Rectangle(519, 453, 5, 5);
                    smallPoint322 = new Rectangle(539, 453, 5, 5);

                    bigPoint1 = new Rectangle(92, 56, 15, 15);
                    bigPoint2 = new Rectangle(454, 56, 15, 15);
                    bigPoint3 = new Rectangle(213, 253, 15, 15);
                    bigPoint4 = new Rectangle(333, 253, 15, 15);
                    bigPoint5 = new Rectangle(113, 367, 15, 15);
                    bigPoint6 = new Rectangle(433, 367, 15, 15);
                    situation = "start";
                    break;
            }

            Refresh();
        }

        private void opencloseTimer_Tick(object sender, EventArgs e)
        {
            switch (situation)
            {
                case "start":
                    opencloseCount++;
                    if (opencloseCount == 1)
                    {
                        switch (startMove)
                        {
                            case "right":
                                startplayerAngle1 = 30;
                                startplayerAngle2 = 300;
                                break;
                            case "left":
                                startplayerAngle1 = 210;
                                startplayerAngle2 = 300;
                                break;
                        }
                        break;
                    }
                    else if (opencloseCount == 2)
                    {
                        startplayerAngle1 = 0;
                        startplayerAngle2 = 360;
                        opencloseCount = 0;
                    }
                    break;
                case "playing":
                    if (up == false && down == false && right == false && left == false)
                    {
                        switch (playerDirection)
                        {
                            case "up":
                                playerAngle1 = 300;
                                playerAngle2 = 300;
                                break;
                            case "down":
                                playerAngle1 = 120;
                                playerAngle2 = 300;
                                break;
                            case "right":
                                playerAngle1 = 30;
                                playerAngle2 = 300;
                                break;
                            case "left":
                                playerAngle1 = 210;
                                playerAngle2 = 300;
                                break;
                        }
                    }
                    else
                    {
                        opencloseCount++;
                        if (opencloseCount == 1)
                        {
                            switch (playerDirection)
                            {
                                case "up":
                                    playerAngle1 = 300;
                                    playerAngle2 = 300;
                                    break;
                                case "down":
                                    playerAngle1 = 120;
                                    playerAngle2 = 300;
                                    break;
                                case "right":
                                    playerAngle1 = 30;
                                    playerAngle2 = 300;
                                    break;
                                case "left":
                                    playerAngle1 = 210;
                                    playerAngle2 = 300;
                                    break;
                            }
                        }
                        else if (opencloseCount == 2)
                        {
                            playerAngle1 = 0;
                            playerAngle2 = 360;
                            opencloseCount = 0;
                        }
                    }

                    break;
                case "gameover":
                    if (gameoverCount <= 10)
                    {
                        playerAngle1 = 300;
                        playerAngle2 = 300;
                    }
                    else if (gameoverCount <= 20)
                    {
                        playerAngle1 = 320;
                        playerAngle2 = 260;
                    }
                    else if (gameoverCount <= 30)
                    {
                        playerAngle1 = 340;
                        playerAngle2 = 220;
                    }
                    else if (gameoverCount <= 40)
                    {
                        playerAngle1 = 360;
                        playerAngle2 = 180;
                    }
                    else if (gameoverCount <= 50)
                    {
                        playerAngle1 = 380;
                        playerAngle2 = 140;
                    }
                    else if (gameoverCount <= 60)
                    {
                        playerAngle1 = 400;
                        playerAngle2 = 100;
                    }
                    else if (gameoverCount <= 70)
                    {
                        playerAngle1 = 420;
                        playerAngle2 = 60;
                    }
                    else if (gameoverCount <= 80)
                    {
                        playerAngle1 = 440;
                        playerAngle2 = 20;
                    }
                    else if (gameoverCount < 90)
                    {
                        playerAngle1 = 450;
                        playerAngle2 = 0;
                    }
                    else if (gameoverCount >= 90)
                    {
                        gameoverTimer.Enabled = false;
                        gameoverCount = 0;
                        situation = "playing";
                        playerDirection = "";
                        lifecheck = "No";
                        player.Location = new Point(273, 447);
                        playerAngle1 = 0;
                        playerAngle2 = 360;
                        playerTimer.Enabled = true;
                    }
                    break;
                case "dead":
                    if (gameoverCount <= 20)
                    {
                        playerAngle1 = 300;
                        playerAngle2 = 300;
                    }
                    else if (gameoverCount <= 40)
                    {
                        playerAngle1 = 320;
                        playerAngle2 = 260;
                    }
                    else if (gameoverCount <= 60)
                    {
                        playerAngle1 = 340;
                        playerAngle2 = 220;
                    }
                    else if (gameoverCount <= 80)
                    {
                        playerAngle1 = 360;
                        playerAngle2 = 180;
                    }
                    else if (gameoverCount <= 100)
                    {
                        playerAngle1 = 380;
                        playerAngle2 = 140;
                    }
                    else if (gameoverCount <= 120)
                    {
                        playerAngle1 = 400;
                        playerAngle2 = 100;
                    }
                    else if (gameoverCount <= 140)
                    {
                        playerAngle1 = 420;
                        playerAngle2 = 60;
                    }
                    else if (gameoverCount <= 160)
                    {
                        playerAngle1 = 440;
                        playerAngle2 = 20;
                    }
                    else if (gameoverCount < 180)
                    {
                        playerAngle1 = 450;
                        playerAngle2 = 0;
                    }
                    else if (gameoverCount >= 200)
                    {
                        gameoverTimer.Enabled = false;
                        gameoverCount = 0;
                        situation = "reset";
                        playerDirection = "";
                        lifecheck = "No";
                        playerTimer.Enabled = true;
                    }
                    break;
            }
            Refresh();
        }

        private void enemyTimer_Tick(object sender, EventArgs e)
        {
            if (situation == "start")
            {

            }
            else
            {
                Rectangle enemy1 = new Rectangle(enemy1X, enemy1Y, 16, 16);
                Rectangle enemy2 = new Rectangle(enemy2X, enemy2Y, 16, 16);
                Rectangle enemy3 = new Rectangle(enemy3X, enemy3Y, 16, 16);
                Rectangle enemy4 = new Rectangle(enemy4X, enemy4Y, 16, 16);
                Rectangle enemy5 = new Rectangle(enemy5X, enemy5Y, 16, 16);
                Rectangle enemy6 = new Rectangle(enemy6X, enemy6Y, 16, 16);
                Rectangle enemy7 = new Rectangle(enemy7X, enemy7Y, 16, 16);
                Rectangle enemy8 = new Rectangle(enemy8X, enemy8Y, 16, 16);

                enemy1RandNum = enemy1RandGen.Next(1, 101);
                enemy2RandNum = enemy2RandGen.Next(1, 101);
                enemy3RandNum = enemy3RandGen.Next(1, 101);
                enemy4RandNum = enemy4RandGen.Next(1, 101);
                enemy7RandNum = enemy7RandGen.Next(1, 101);
                enemy8RandNum = enemy8RandGen.Next(1, 101);

                if (enemy1RandNum <= 50)
                {
                    enemy1Dire2 = 1;
                }
                else
                {
                    enemy1Dire2 = 2;
                }
                if (enemy1RandNum <= 33)
                {
                    enemy1Dire3 = 1;
                }
                else if (enemy1RandNum <= 66)
                {
                    enemy1Dire3 = 2;
                }
                else
                {
                    enemy1Dire3 = 3;
                }

                if (enemy2RandNum <= 50)
                {
                    enemy2Dire2 = 1;
                }
                else
                {
                    enemy2Dire2 = 2;
                }
                if (enemy2RandNum <= 33)
                {
                    enemy2Dire3 = 1;
                }
                else if (enemy2RandNum <= 66)
                {
                    enemy2Dire3 = 2;
                }
                else
                {
                    enemy2Dire3 = 3;
                }

                if (enemy3RandNum <= 50)
                {
                    enemy3Dire2 = 1;
                }
                else
                {
                    enemy3Dire2 = 2;
                }
                if (enemy3RandNum <= 33)
                {
                    enemy3Dire3 = 1;
                }
                else if (enemy3RandNum <= 66)
                {
                    enemy3Dire3 = 2;
                }
                else
                {
                    enemy3Dire3 = 3;
                }

                if (enemy4RandNum <= 50)
                {
                    enemy4Dire2 = 1;
                }
                else
                {
                    enemy4Dire2 = 2;
                }
                if (enemy4RandNum <= 33)
                {
                    enemy4Dire3 = 1;
                }
                else if (enemy4RandNum <= 66)
                {
                    enemy4Dire3 = 2;
                }
                else
                {
                    enemy4Dire3 = 3;
                }

                if (enemy7RandNum <= 50)
                {
                    enemy7Dire2 = 1;
                }
                else
                {
                    enemy7Dire2 = 2;
                }
                if (enemy7RandNum <= 33)
                {
                    enemy7Dire3 = 1;
                }
                else if (enemy7RandNum <= 66)
                {
                    enemy7Dire3 = 2;
                }
                else
                {
                    enemy7Dire3 = 3;
                }
                if (enemy7RandNum <= 25)
                {
                    enemy7Dire4 = 1;
                }
                else if (enemy7RandNum <= 50)
                {
                    enemy7Dire4 = 2;
                }
                else if (enemy7RandNum <= 75)
                {
                    enemy7Dire4 = 3;
                }
                else
                {
                    enemy7Dire4 = 4;
                }

                if (enemy8RandNum <= 50)
                {
                    enemy8Dire2 = 1;
                }
                else
                {
                    enemy8Dire2 = 2;
                }
                if (enemy8RandNum <= 33)
                {
                    enemy8Dire3 = 1;
                }
                else if (enemy8RandNum <= 66)
                {
                    enemy8Dire3 = 2;
                }
                else
                {
                    enemy8Dire3 = 3;
                }
                if (enemy8RandNum <= 25)
                {
                    enemy8Dire4 = 1;
                }
                else if (enemy8RandNum <= 50)
                {
                    enemy8Dire4 = 2;
                }
                else if (enemy8RandNum <= 75)
                {
                    enemy8Dire4 = 3;
                }
                else
                {
                    enemy8Dire4 = 4;
                }

                //Enemy1
                if (enemy1.Location == new Point(13, 17))
                {
                    enemy1Location = "T1";
                }
                else if (enemy1.Location == new Point(93, 17))
                {
                    enemy1Location = "T2";
                }
                else if (enemy1.Location == new Point(133, 17))
                {
                    enemy1Location = "T3";
                }
                else if (enemy1.Location == new Point(13, 57))
                {
                    enemy1Location = "T4";
                }
                else if (enemy1.Location == new Point(93, 57))
                {
                    enemy1Location = "T5";
                }
                else if (enemy1.Location == new Point(13, 97))
                {
                    enemy1Location = "T6";
                }
                else if (enemy1.Location == new Point(53, 97))
                {
                    enemy1Location = "T7";
                }
                else if (enemy1.Location == new Point(93, 97))
                {
                    enemy1Location = "T8";
                }
                else if (enemy1.Location == new Point(133, 97))
                {
                    enemy1Location = "T9";
                }
                else if (enemy1.Location == new Point(53, 157))
                {
                    enemy1Location = "T10";
                }
                else if (enemy1.Location == new Point(93, 157))
                {
                    enemy1Location = "T11";
                }
                else if (enemy1.Location == new Point(13, 197))
                {
                    enemy1Location = "T12";
                }
                else if (enemy1.Location == new Point(93, 197))
                {
                    enemy1Location = "T13";
                }
                else if (enemy1.Location == new Point(133, 197))
                {
                    enemy1Location = "T16";
                }
                else
                {
                    enemy1Location = "else";
                }

                //Enemy2
                if (enemy2.Location == new Point(133, 117))
                {
                    enemy2Location = "T14";
                }
                else if (enemy2.Location == new Point(133, 157))
                {
                    enemy2Location = "T15";
                }
                else if (enemy2.Location == new Point(133, 197))
                {
                    enemy2Location = "T16";
                }
                else if (enemy2.Location == new Point(173, 77))
                {
                    enemy2Location = "T17";
                }
                else if (enemy2.Location == new Point(173, 117))
                {
                    enemy2Location = "T18";
                }
                else if (enemy2.Location == new Point(193, 117))
                {
                    enemy2Location = "T19";
                }
                else if (enemy2.Location == new Point(193, 157))
                {
                    enemy2Location = "T20";
                }
                else if (enemy2.Location == new Point(233, 77))
                {
                    enemy2Location = "T21";
                }
                else if (enemy2.Location == new Point(233, 117))
                {
                    enemy2Location = "T22";
                }
                else if (enemy2.Location == new Point(253, 157))
                {
                    enemy2Location = "T23";
                }
                else if (enemy2.Location == new Point(253, 197))
                {
                    enemy2Location = "T24";
                }
                else if (enemy2.Location == new Point(293, 157))
                {
                    enemy2Location = "T25";
                }
                else if (enemy2.Location == new Point(293, 197))
                {
                    enemy2Location = "T26";
                }
                else if (enemy2.Location == new Point(313, 77))
                {
                    enemy2Location = "T27";
                }
                else if (enemy2.Location == new Point(313, 117))
                {
                    enemy2Location = "T28";
                }
                else if (enemy2.Location == new Point(353, 117))
                {
                    enemy2Location = "T29";
                }
                else if (enemy2.Location == new Point(353, 157))
                {
                    enemy2Location = "T30";
                }
                else if (enemy2.Location == new Point(373, 77))
                {
                    enemy2Location = "T31";
                }
                else if (enemy2.Location == new Point(373, 117))
                {
                    enemy2Location = "T32";
                }
                else if (enemy2.Location == new Point(413, 117))
                {
                    enemy2Location = "T33";
                }
                else if (enemy2.Location == new Point(413, 157))
                {
                    enemy2Location = "T34";
                }
                else if (enemy2.Location == new Point(413, 197))
                {
                    enemy2Location = "T35";
                }
                else
                {
                    enemy2Location = "else";
                }

                //Enemy3
                if (enemy3.Location == new Point(133, 117))
                {
                    enemy3Location = "T14";
                }
                else if (enemy3.Location == new Point(133, 157))
                {
                    enemy3Location = "T15";
                }
                else if (enemy3.Location == new Point(133, 197))
                {
                    enemy3Location = "T16";
                }
                else if (enemy3.Location == new Point(173, 77))
                {
                    enemy3Location = "T17";
                }
                else if (enemy3.Location == new Point(173, 117))
                {
                    enemy3Location = "T18";
                }
                else if (enemy3.Location == new Point(193, 117))
                {
                    enemy3Location = "T19";
                }
                else if (enemy3.Location == new Point(193, 157))
                {
                    enemy3Location = "T20";
                }
                else if (enemy3.Location == new Point(233, 77))
                {
                    enemy3Location = "T21";
                }
                else if (enemy3.Location == new Point(233, 117))
                {
                    enemy3Location = "T22";
                }
                else if (enemy3.Location == new Point(253, 157))
                {
                    enemy3Location = "T23";
                }
                else if (enemy3.Location == new Point(253, 197))
                {
                    enemy3Location = "T24";
                }
                else if (enemy3.Location == new Point(293, 157))
                {
                    enemy3Location = "T25";
                }
                else if (enemy3.Location == new Point(293, 197))
                {
                    enemy3Location = "T26";
                }
                else if (enemy3.Location == new Point(313, 77))
                {
                    enemy3Location = "T27";
                }
                else if (enemy3.Location == new Point(313, 117))
                {
                    enemy3Location = "T28";
                }
                else if (enemy3.Location == new Point(353, 117))
                {
                    enemy3Location = "T29";
                }
                else if (enemy3.Location == new Point(353, 157))
                {
                    enemy3Location = "T30";
                }
                else if (enemy3.Location == new Point(373, 77))
                {
                    enemy3Location = "T31";
                }
                else if (enemy3.Location == new Point(373, 117))
                {
                    enemy3Location = "T32";
                }
                else if (enemy3.Location == new Point(413, 117))
                {
                    enemy3Location = "T33";
                }
                else if (enemy3.Location == new Point(413, 157))
                {
                    enemy3Location = "T34";
                }
                else if (enemy3.Location == new Point(413, 197))
                {
                    enemy3Location = "T35";
                }
                else
                {
                    enemy3Location = "else";
                }

                //Enemy4
                if (enemy4.Location == new Point(413, 197))
                {
                    enemy4Location = "T35";
                }
                else if (enemy4.Location == new Point(413, 17))
                {
                    enemy4Location = "T36";
                }
                else if (enemy4.Location == new Point(453, 17))
                {
                    enemy4Location = "T37";
                }
                else if (enemy4.Location == new Point(533, 17))
                {
                    enemy4Location = "T38";
                }
                else if (enemy4.Location == new Point(453, 57))
                {
                    enemy4Location = "T39";
                }
                else if (enemy4.Location == new Point(533, 57))
                {
                    enemy4Location = "T40";
                }
                else if (enemy4.Location == new Point(413, 97))
                {
                    enemy4Location = "T41";
                }
                else if (enemy4.Location == new Point(453, 97))
                {
                    enemy4Location = "T42";
                }
                else if (enemy4.Location == new Point(493, 97))
                {
                    enemy4Location = "T43";
                }
                else if (enemy4.Location == new Point(533, 97))
                {
                    enemy4Location = "T44";
                }
                else if (enemy4.Location == new Point(453, 157))
                {
                    enemy4Location = "T45";
                }
                else if (enemy4.Location == new Point(493, 157))
                {
                    enemy4Location = "T46";
                }
                else if (enemy4.Location == new Point(453, 197))
                {
                    enemy4Location = "T47";
                }
                else if (enemy4.Location == new Point(533, 197))
                {
                    enemy4Location = "T48";
                }
                else
                {
                    enemy4Location = "else";
                }

                //Enemy5
                if (enemy5.Location == new Point(63, 197))
                {
                    enemy5Location = "M1";
                }
                else if (enemy5.Location == new Point(183, 197))
                {
                    enemy5Location = "M3";
                }
                else if (enemy5.Location == new Point(303, 197))
                {
                    enemy5Location = "M6";
                }
                else if (enemy5.Location == new Point(423, 197))
                {
                    enemy5Location = "M10";
                }
                else if (enemy5.Location == new Point(63, 242))
                {
                    enemy5Location = "M15";
                }
                else if (enemy5.Location == new Point(483, 242))
                {
                    enemy5Location = "M17";
                }
                else if (enemy5.Location == new Point(63, 287))
                {
                    enemy5Location = "M21";
                }
                else if (enemy5.Location == new Point(183, 287))
                {
                    enemy5Location = "M23";
                }
                else if (enemy5.Location == new Point(303, 287))
                {
                    enemy5Location = "M25";
                }
                else if (enemy5.Location == new Point(423, 287))
                {
                    enemy5Location = "M28";
                }
                else if (enemy5.Location == new Point(483, 287))
                {
                    enemy5Location = "M29";
                }
                else if (enemy5.Location == new Point(560, 242))
                {
                    enemy5Location = "warpR";
                }
                else if (enemy5.Location == new Point(-19, 242))
                {
                    enemy5Location = "W1";
                }
                else
                {
                    enemy5Location = "else";
                }

                //Enemy6
                if (enemy6.Location == new Point(63, 197))
                {
                    enemy6Location = "M1";
                }
                else if (enemy6.Location == new Point(123, 197))
                {
                    enemy6Location = "M2";
                }
                else if (enemy6.Location == new Point(243, 197))
                {
                    enemy6Location = "M5";
                }
                else if (enemy6.Location == new Point(363, 197))
                {
                    enemy6Location = "M8";
                }
                else if (enemy6.Location == new Point(63, 242))
                {
                    enemy6Location = "M15";
                }
                else if (enemy6.Location == new Point(483, 242))
                {
                    enemy6Location = "M17";
                }
                else if (enemy6.Location == new Point(63, 287))
                {
                    enemy6Location = "M21";
                }
                else if (enemy6.Location == new Point(123, 287))
                {
                    enemy6Location = "M22";
                }
                else if (enemy6.Location == new Point(243, 287))
                {
                    enemy6Location = "M24";
                }
                else if (enemy6.Location == new Point(363, 287))
                {
                    enemy6Location = "M26";
                }
                else if (enemy6.Location == new Point(483, 287))
                {
                    enemy6Location = "M29";
                }
                else if (enemy6.Location == new Point(-20, 242))
                {
                    enemy6Location = "warpL";
                }
                else if (enemy6.Location == new Point(559, 242))
                {
                    enemy6Location = "W2";
                }
                else
                {
                    enemy6Location = "else";
                }

                //Enemy7
                if (enemy7.Location == new Point(13, 287))
                {
                    enemy7Location = "B1";
                }
                else if (enemy7.Location == new Point(113, 287))
                {
                    enemy7Location = "B2";
                }
                else if (enemy7.Location == new Point(273, 287))
                {
                    enemy7Location = "B3";
                }
                else if (enemy7.Location == new Point(13, 327))
                {
                    enemy7Location = "B6";
                }
                else if (enemy7.Location == new Point(73, 327))
                {
                    enemy7Location = "B7";
                }
                else if (enemy7.Location == new Point(113, 327))
                {
                    enemy7Location = "B8";
                }
                else if (enemy7.Location == new Point(153, 327))
                {
                    enemy7Location = "B9";
                }
                else if (enemy7.Location == new Point(193, 327))
                {
                    enemy7Location = "B10";
                }
                else if (enemy7.Location == new Point(273, 327))
                {
                    enemy7Location = "B11";
                }
                else if (enemy7.Location == new Point(13, 367))
                {
                    enemy7Location = "B17";
                }
                else if (enemy7.Location == new Point(73, 367))
                {
                    enemy7Location = "B18";
                }
                else if (enemy7.Location == new Point(113, 367))
                {
                    enemy7Location = "B19";
                }
                else if (enemy7.Location == new Point(153, 367))
                {
                    enemy7Location = "B20";
                }
                else if (enemy7.Location == new Point(173, 367))
                {
                    enemy7Location = "B21";
                }
                else if (enemy7.Location == new Point(193, 367))
                {
                    enemy7Location = "B22";
                }
                else if (enemy7.Location == new Point(213, 367))
                {
                    enemy7Location = "B23";
                }
                else if (enemy7.Location == new Point(13, 407))
                {
                    enemy7Location = "B31";
                }
                else if (enemy7.Location == new Point(73, 407))
                {
                    enemy7Location = "B32";
                }
                else if (enemy7.Location == new Point(173, 407))
                {
                    enemy7Location = "B33";
                }
                else if (enemy7.Location == new Point(213, 407))
                {
                    enemy7Location = "B34";
                }
                else if (enemy7.Location == new Point(253, 407))
                {
                    enemy7Location = "B35";
                }
                else if (enemy7.Location == new Point(13, 447))
                {
                    enemy7Location = "B41";
                }
                else if (enemy7.Location == new Point(73, 447))
                {
                    enemy7Location = "B42";
                }
                else if (enemy7.Location == new Point(213, 447))
                {
                    enemy7Location = "B43";
                }
                else if (enemy7.Location == new Point(253, 447))
                {
                    enemy7Location = "B44";
                }
                else
                {
                    enemy7Location = "else";
                }

                //Enemy8
                if (enemy8.Location == new Point(273, 287))
                {
                    enemy8Location = "B3";
                }
                else if (enemy8.Location == new Point(433, 287))
                {
                    enemy8Location = "B4";
                }
                else if (enemy8.Location == new Point(533, 287))
                {
                    enemy8Location = "B5";
                }
                else if (enemy8.Location == new Point(273, 327))
                {
                    enemy8Location = "B11";
                }
                else if (enemy8.Location == new Point(353, 327))
                {
                    enemy8Location = "B12";
                }
                else if (enemy8.Location == new Point(393, 327))
                {
                    enemy8Location = "B13";
                }
                else if (enemy8.Location == new Point(433, 327))
                {
                    enemy8Location = "B14";
                }
                else if (enemy8.Location == new Point(473, 327))
                {
                    enemy8Location = "B15";
                }
                else if (enemy8.Location == new Point(533, 327))
                {
                    enemy8Location = "B16";
                }
                else if (enemy8.Location == new Point(333, 367))
                {
                    enemy8Location = "B24";
                }
                else if (enemy8.Location == new Point(353, 367))
                {
                    enemy8Location = "B25";
                }
                else if (enemy8.Location == new Point(373, 367))
                {
                    enemy8Location = "B26";
                }
                else if (enemy8.Location == new Point(393, 367))
                {
                    enemy8Location = "B27";
                }
                else if (enemy8.Location == new Point(433, 367))
                {
                    enemy8Location = "B28";
                }
                else if (enemy8.Location == new Point(473, 367))
                {
                    enemy8Location = "B29";
                }
                else if (enemy8.Location == new Point(533, 367))
                {
                    enemy8Location = "B30";
                }
                else if (enemy8.Location == new Point(293, 407))
                {
                    enemy8Location = "B36";
                }
                else if (enemy8.Location == new Point(333, 407))
                {
                    enemy8Location = "B37";
                }
                else if (enemy8.Location == new Point(373, 407))
                {
                    enemy8Location = "B38";
                }
                else if (enemy8.Location == new Point(473, 407))
                {
                    enemy8Location = "B39";
                }
                else if (enemy8.Location == new Point(533, 407))
                {
                    enemy8Location = "B40";
                }
                else if (enemy8.Location == new Point(293, 447))
                {
                    enemy8Location = "B45";
                }
                else if (enemy8.Location == new Point(333, 447))
                {
                    enemy8Location = "B46";
                }
                else if (enemy8.Location == new Point(473, 447))
                {
                    enemy8Location = "B47";
                }
                else if (enemy8.Location == new Point(533, 447))
                {
                    enemy8Location = "B48";
                }
                else
                {
                    enemy8Location = "else";
                }

                switch (enemy1Location)
                {
                    case "T1":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        break;
                    case "T2":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        break;
                    case "T3":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        break;
                    case "T4":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        break;
                    case "T5":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        break;
                    case "T6":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        break;
                    case "T7":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        break;
                    case "T8":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        break;
                    case "T9":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        break;
                    case "T10":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        break;
                    case "T11":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1.Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        break;
                    case "T12":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        break;
                    case "T13":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        break;
                    case "T14":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        break;
                    case "T15":
                        if (enemy1Dire3 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire3 == 2)
                        {
                            enemy1X += enemySpeed;
                            enemy1Direction = "right";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy1Y += enemySpeed;
                            enemy1Direction = "down";
                        }
                        break;
                    case "T16":
                        if (enemy1Dire2 == 1)
                        {
                            enemy1Y -= enemySpeed;
                            enemy1Direction = "up";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy1X -= enemySpeed;
                            enemy1Direction = "left";
                        }
                        break;
                    case "else":
                        if (enemy1Direction == "right")
                        {
                            enemy1X += enemySpeed;
                        }
                        else if (enemy1Direction == "left")
                        {
                            enemy1X -= enemySpeed;
                        }
                        else if (enemy1Direction == "up")
                        {
                            enemy1Y -= enemySpeed;
                        }
                        else if (enemy1Direction == "down")
                        {
                            enemy1Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy2Location)
                {
                    case "T14":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        break;
                    case "T15":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T16":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        break;
                    case "T17":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        else if (enemy1Dire2 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        break;
                    case "T18":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T19":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T20":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T21":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T22":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T23":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T24":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy1Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T25":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T26":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T27":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T28":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T29":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T30":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T31":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T32":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X += enemySpeed;
                            enemy2Direction = "right";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "T33":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T34":
                        if (enemy2Dire3 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire3 == 2)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        else if (enemy2Dire3 == 3)
                        {
                            enemy2Y += enemySpeed;
                            enemy2Direction = "down";
                        }
                        break;
                    case "T35":
                        if (enemy2Dire2 == 1)
                        {
                            enemy2Y -= enemySpeed;
                            enemy2Direction = "up";
                        }
                        else if (enemy2Dire2 == 2)
                        {
                            enemy2X -= enemySpeed;
                            enemy2Direction = "left";
                        }
                        break;
                    case "else":
                        if (enemy2Direction == "right")
                        {
                            enemy2X += enemySpeed;
                        }
                        else if (enemy2Direction == "left")
                        {
                            enemy2X -= enemySpeed;
                        }
                        else if (enemy2Direction == "up")
                        {
                            enemy2Y -= enemySpeed;
                        }
                        else if (enemy2Direction == "down")
                        {
                            enemy2Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy3Location)
                {
                    case "T14":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        break;
                    case "T15":
                        if (enemy3Dire3 == 3)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T16":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        break;
                    case "T17":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        break;
                    case "T18":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T19":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T20":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T21":
                        if (enemy3Dire3 == 3)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T22":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T23":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T24":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T25":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T26":
                        if (enemy3Dire3 == 3)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T27":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T28":
                        if (enemy3Dire3 == 1)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T29":
                        if (enemy3Dire3 == 2)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T30":
                        if (enemy3Dire3 == 3)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T31":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T32":
                        if (enemy3Dire3 == 1)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 3)
                        {
                            enemy3X += enemySpeed;
                            enemy3Direction = "right";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "T33":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T34":
                        if (enemy3Dire3 == 3)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire3 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        else if (enemy3Dire3 == 2)
                        {
                            enemy3Y += enemySpeed;
                            enemy3Direction = "down";
                        }
                        break;
                    case "T35":
                        if (enemy3Dire2 == 2)
                        {
                            enemy3Y -= enemySpeed;
                            enemy3Direction = "up";
                        }
                        else if (enemy3Dire2 == 1)
                        {
                            enemy3X -= enemySpeed;
                            enemy3Direction = "left";
                        }
                        break;
                    case "else":
                        if (enemy3Direction == "right")
                        {
                            enemy3X += enemySpeed;
                        }
                        else if (enemy3Direction == "left")
                        {
                            enemy3X -= enemySpeed;
                        }
                        else if (enemy3Direction == "up")
                        {
                            enemy3Y -= enemySpeed;
                        }
                        else if (enemy3Direction == "down")
                        {
                            enemy3Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy4Location)
                {
                    case "T35":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        break;
                    case "T36":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        break;
                    case "T37":
                        if (enemy4Dire3 == 1)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        else if (enemy4Dire3 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        else if (enemy4Dire3 == 3)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        break;
                    case "T38":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        break;
                    case "T39":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        break;
                    case "T40":
                        if (enemy4Dire3 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire3 == 2)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        else if (enemy4Dire3 == 3)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        break;
                    case "T41":
                        if (enemy4Dire3 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire3 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        else if (enemy4Dire3 == 3)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        break;
                    case "T42":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        break;
                    case "T43":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        break;
                    case "T44":
                        if (enemy4Dire3 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire3 == 2)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        else if (enemy4Dire3 == 3)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        break;
                    case "T45":
                        if (enemy4Dire3 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire3 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        else if (enemy4Dire3 == 3)
                        {
                            enemy4Y += enemySpeed;
                            enemy4Direction = "down";
                        }
                        break;
                    case "T46":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        break;
                    case "T47":
                        if (enemy4Dire3 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire3 == 2)
                        {
                            enemy4X += enemySpeed;
                            enemy4Direction = "right";
                        }
                        else if (enemy4Dire3 == 3)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        break;
                    case "T48":
                        if (enemy4Dire2 == 1)
                        {
                            enemy4Y -= enemySpeed;
                            enemy4Direction = "up";
                        }
                        else if (enemy4Dire2 == 2)
                        {
                            enemy4X -= enemySpeed;
                            enemy4Direction = "left";
                        }
                        break;
                    case "else":
                        if (enemy4Direction == "right")
                        {
                            enemy4X += enemySpeed;
                        }
                        else if (enemy4Direction == "left")
                        {
                            enemy4X -= enemySpeed;
                        }
                        else if (enemy4Direction == "up")
                        {
                            enemy4Y -= enemySpeed;
                        }
                        else if (enemy4Direction == "down")
                        {
                            enemy4Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy5Location)
                {
                    case "M1":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M3":
                        enemy5Y += enemySpeed;
                        enemy5Direction = "down";
                        break;
                    case "M5":
                        enemy5Y += enemySpeed;
                        enemy5Direction = "down";
                        break;
                    case "M6":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M8":
                        enemy5Y += enemySpeed;
                        enemy5Direction = "down";
                        break;
                    case "M10":
                        enemy5Y += enemySpeed;
                        enemy5Direction = "down";
                        break;
                    case "M15":
                        enemy5Y -= enemySpeed;
                        enemy5Direction = "up";
                        break;
                    case "M17":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M22":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M23":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M25":
                        enemy5Y -= enemySpeed;
                        enemy5Direction = "up";
                        break;
                    case "M26":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M28":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "M29":
                        enemy5Y -= enemySpeed;
                        enemy5Direction = "up";
                        break;
                    case "warpR":
                        enemy5X = -19;
                        break;
                    case "W1":
                        enemy5X += enemySpeed;
                        enemy5Direction = "right";
                        break;
                    case "else":
                        if (enemy5Direction == "right")
                        {
                            enemy5X += enemySpeed;
                        }
                        else if (enemy5Direction == "left")
                        {
                            enemy5X -= enemySpeed;
                        }
                        else if (enemy5Direction == "up")
                        {
                            enemy5Y -= enemySpeed;
                        }
                        else if (enemy5Direction == "down")
                        {
                            enemy5Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy6Location)
                {
                    case "M1":
                        enemy6Y += enemySpeed;
                        enemy6Direction = "down";
                        break;
                    case "M2":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "M5":
                        enemy6Y += enemySpeed;
                        enemy6Direction = "down";
                        break;
                    case "M8":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "M11":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "M15":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "M17":
                        enemy6Y += enemySpeed;
                        enemy6Direction = "down";
                        break;
                    case "M22":
                        enemy6Y -= enemySpeed;
                        enemy6Direction = "up";
                        break;
                    case "M24":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "M26":
                        enemy6Y -= enemySpeed;
                        enemy6Direction = "up";
                        break;
                    case "M29":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "warpL":
                        enemy6X = 559;
                        break;
                    case "W2":
                        enemy6X -= enemySpeed;
                        enemy6Direction = "left";
                        break;
                    case "else":
                        if (enemy6Direction == "right")
                        {
                            enemy6X += enemySpeed;
                        }
                        else if (enemy6Direction == "left")
                        {
                            enemy6X -= enemySpeed;
                        }
                        else if (enemy6Direction == "up")
                        {
                            enemy6Y -= enemySpeed;
                        }
                        else if (enemy6Direction == "down")
                        {
                            enemy6Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy7Location)
                {
                    case "B1":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B2":
                        if (enemy7Dire3 == 3)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire3 == 2)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B3":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B6":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B7":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B8":
                        if (enemy7Dire3 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        break;
                    case "B9":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B10":
                        if (enemy7Dire2 == 1)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 2)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B11":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B17":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        break;
                    case "B18":
                        if (enemy7Dire3 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B19":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        break;
                    case "B20":
                        if (enemy7Dire2 == 3)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire2 == 2)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B21":
                        if (enemy7Dire3 == 2)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        break;
                    case "B22":
                        if (enemy7Dire3 == 1)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 2)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B23":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B31":
                        if (enemy7Dire3 == 3)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire3 == 2)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        break;
                    case "B32":
                        if (enemy7Dire3 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B33":
                        if (enemy7Dire3 == 1)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 2)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B34":
                        if (enemy7Dire4 == 2)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        else if (enemy7Dire4 == 1)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire4 == 3)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire4 == 4)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B35":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y += enemySpeed;
                            enemy7Direction = "down";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B41":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        break;
                    case "B42":
                        if (enemy7Dire3 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire3 == 1)
                        {
                            enemy7X += enemySpeed;
                            enemy7Direction = "right";
                        }
                        else if (enemy7Dire3 == 3)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B43":
                        if (enemy7Dire2 == 2)
                        {
                            enemy7Y -= enemySpeed;
                            enemy7Direction = "up";
                        }
                        else if (enemy7Dire2 == 1)
                        {
                            enemy7X -= enemySpeed;
                            enemy7Direction = "left";
                        }
                        break;
                    case "B44":
                        enemy7Y -= enemySpeed;
                        enemy7Direction = "up";
                        break;
                    case "else":
                        if (enemy7Direction == "right")
                        {
                            enemy7X += enemySpeed;
                        }
                        else if (enemy7Direction == "left")
                        {
                            enemy7X -= enemySpeed;
                        }
                        else if (enemy7Direction == "up")
                        {
                            enemy7Y -= enemySpeed;
                        }
                        else if (enemy7Direction == "down")
                        {
                            enemy7Y += enemySpeed;
                        }
                        break;
                }
                switch (enemy8Location)
                {
                    case "B3":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B4":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B5":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B11":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B12":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B13":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B14":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        break;
                    case "B15":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B16":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B24":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B25":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B26":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B27":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B28":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B29":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B30":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B36":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B37":
                        if (enemy8Dire4 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire4 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire4 == 4)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire4 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B38":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B39":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B40":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y += enemySpeed;
                            enemy8Direction = "down";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B45":
                        enemy8Y -= enemySpeed;
                        enemy8Direction = "up";
                        break;
                    case "B46":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        break;
                    case "B47":
                        if (enemy8Dire3 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire3 == 1)
                        {
                            enemy8X += enemySpeed;
                            enemy8Direction = "right";
                        }
                        else if (enemy8Dire3 == 3)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "B48":
                        if (enemy8Dire2 == 2)
                        {
                            enemy8Y -= enemySpeed;
                            enemy8Direction = "up";
                        }
                        else if (enemy8Dire2 == 1)
                        {
                            enemy8X -= enemySpeed;
                            enemy8Direction = "left";
                        }
                        break;
                    case "else":
                        if (enemy8Direction == "right")
                        {
                            enemy8X += enemySpeed;
                        }
                        else if (enemy8Direction == "left")
                        {
                            enemy8X -= enemySpeed;
                        }
                        else if (enemy8Direction == "up")
                        {
                            enemy8Y -= enemySpeed;
                        }
                        else if (enemy8Direction == "down")
                        {
                            enemy8Y += enemySpeed;
                        }
                        break;
                }

                if (powerup == "true")
                {
                    enemyTimer.Interval = 55;
                    if (enemyWeakColor == "blue")
                    {
                        enemy1Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy2Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy3Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy4Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy5Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy6Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy7Pic.BackgroundImage = Properties.Resources.enemyWeak;
                        enemy8Pic.BackgroundImage = Properties.Resources.enemyWeak;
                    }
                    else if (enemyWeakColor == "white")
                    {
                        enemy1Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy2Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy3Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy4Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy5Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy6Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy7Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                        enemy8Pic.BackgroundImage = Properties.Resources.enemyWeak2;
                    }
                }
                else
                {
                    enemyTimer.Interval = 1;
                    switch (enemy1Direction)
                    {
                        case "right":
                            enemy1Pic.BackgroundImage = Properties.Resources.enemy1R;
                            break;
                        case "left":
                            enemy1Pic.BackgroundImage = Properties.Resources.enemy1L;
                            break;
                        case "up":
                            enemy1Pic.BackgroundImage = Properties.Resources.enemy1U;
                            break;
                        case "down":
                            enemy1Pic.BackgroundImage = Properties.Resources.enemy1D;
                            break;
                    }
                    switch (enemy2Direction)
                    {
                        case "right":
                            enemy2Pic.BackgroundImage = Properties.Resources.enemy2R;
                            break;
                        case "left":
                            enemy2Pic.BackgroundImage = Properties.Resources.enemy2L;
                            break;
                        case "up":
                            enemy2Pic.BackgroundImage = Properties.Resources.enemy2U;
                            break;
                        case "down":
                            enemy2Pic.BackgroundImage = Properties.Resources.enemy2D;
                            break;
                    }
                    switch (enemy3Direction)
                    {
                        case "right":
                            enemy3Pic.BackgroundImage = Properties.Resources.enemy3R;
                            break;
                        case "left":
                            enemy3Pic.BackgroundImage = Properties.Resources.enemy3L;
                            break;
                        case "up":
                            enemy3Pic.BackgroundImage = Properties.Resources.enemy3U;
                            break;
                        case "down":
                            enemy3Pic.BackgroundImage = Properties.Resources.enemy3D;
                            break;
                    }
                    switch (enemy4Direction)
                    {
                        case "right":
                            enemy4Pic.BackgroundImage = Properties.Resources.enemy4R;
                            break;
                        case "left":
                            enemy4Pic.BackgroundImage = Properties.Resources.enemy4L;
                            break;
                        case "up":
                            enemy4Pic.BackgroundImage = Properties.Resources.enemy4U;
                            break;
                        case "down":
                            enemy4Pic.BackgroundImage = Properties.Resources.enemy4D;
                            break;
                    }
                    switch (enemy5Direction)
                    {
                        case "right":
                            enemy5Pic.BackgroundImage = Properties.Resources.enemy5R;
                            break;
                        case "left":
                            enemy5Pic.BackgroundImage = Properties.Resources.enemy5L;
                            break;
                        case "up":
                            enemy5Pic.BackgroundImage = Properties.Resources.enemy5U;
                            break;
                        case "down":
                            enemy5Pic.BackgroundImage = Properties.Resources.enemy5D;
                            break;
                    }
                    switch (enemy6Direction)
                    {
                        case "right":
                            enemy6Pic.BackgroundImage = Properties.Resources.enemy6R;
                            break;
                        case "left":
                            enemy6Pic.BackgroundImage = Properties.Resources.enemy6L;
                            break;
                        case "up":
                            enemy6Pic.BackgroundImage = Properties.Resources.enemy6U;
                            break;
                        case "down":
                            enemy6Pic.BackgroundImage = Properties.Resources.enemy6D;
                            break;
                    }
                    switch (enemy7Direction)
                    {
                        case "right":
                            enemy7Pic.BackgroundImage = Properties.Resources.enemy7R;
                            break;
                        case "left":
                            enemy7Pic.BackgroundImage = Properties.Resources.enemy7L;
                            break;
                        case "up":
                            enemy7Pic.BackgroundImage = Properties.Resources.enemy7U;
                            break;
                        case "down":
                            enemy7Pic.BackgroundImage = Properties.Resources.enemy7D;
                            break;
                    }
                    switch (enemy8Direction)
                    {
                        case "right":
                            enemy8Pic.BackgroundImage = Properties.Resources.enemy8R;
                            break;
                        case "left":
                            enemy8Pic.BackgroundImage = Properties.Resources.enemy8L;
                            break;
                        case "up":
                            enemy8Pic.BackgroundImage = Properties.Resources.enemy8U;
                            break;
                        case "down":
                            enemy8Pic.BackgroundImage = Properties.Resources.enemy8D;
                            break;
                    }
                }
            }
            Refresh();
        }

        private void powerupTimer_Tick(object sender, EventArgs e)
        {
            powerupCount++;
            if (powerupCount < 50)
            {
                if (powerupCount % 10 == 1)
                {
                    bigSound.Play();
                }
            }
            playerTimer.Interval = 1;
            if (powerupCount >= 42 && powerupCount <= 60)
            {
                if (powerupCount == 45)
                {
                    enemyWeakColor = "white";
                }
                else if (powerupCount == 48)
                {
                    enemyWeakColor = "blue";
                }
                else if (powerupCount == 51)
                {
                    enemyWeakColor = "white";
                }
                else if (powerupCount == 54)
                {
                    enemyWeakColor = "blue";
                }
                else if (powerupCount == 57)
                {
                    enemyWeakColor = "white";
                }
                else if (powerupCount == 60)
                {
                    playerTimer.Interval = 10;
                    enemyWeakColor = "blue";
                    powerup = "false";
                    powerupCount = 0;
                    powerupTimer.Enabled = false;
                }
            }
            Refresh();
        }

        private void gameoverTimer_Tick(object sender, EventArgs e)
        {
            gameoverCount++;
            if (lifecheck == "No")
            {
                if (life == 3)
                {
                    life = 2;
                    lifecheck = "Yes";
                }
                else if (life == 2)
                {
                    life = 1;
                    lifecheck = "Yes";
                }
            }
            Refresh();
        }

        private void startTimer_Tick(object sender, EventArgs e)
        {
            startCount++;
            int X1 = startEnemy1.Location.X;
            int Y1 = startEnemy1.Location.Y;
            int X2 = startEnemy2.Location.X;
            int Y2 = startEnemy2.Location.Y;
            int X3 = startEnemy3.Location.X;
            int Y3 = startEnemy3.Location.Y;
            int X4 = startEnemy4.Location.X;
            int Y4 = startEnemy4.Location.Y;

            startEnemy1.Visible = true;
            startEnemy2.Visible = true;
            startEnemy3.Visible = true;
            startEnemy4.Visible = true;

            if (startgame == "Yes")
            {
                waitCount++;
                if (waitCount == 1)
                {
                    beginningSound.Play();
                }
                else if(waitCount < 10) { }
                else
                {
                    if (startMove == "left")
                    {
                        startEnemy1.BackgroundImage = Properties.Resources.startEnemy1L;
                        startEnemy2.BackgroundImage = Properties.Resources.startEnemy2L;
                        startEnemy3.BackgroundImage = Properties.Resources.startEnemy3L;
                        startEnemy4.BackgroundImage = Properties.Resources.startEnemy4L;

                        X1 -= 10;
                        X2 -= 10;
                        X3 -= 10;
                        X4 -= 10;
                        startplayer.X -= 8;

                        if (X4 <= -35)
                        {
                            startMove = "right";
                            startplayer.X = -180;
                        }
                    }
                    else if (startMove == "right")
                    {
                        startEnemy1.BackgroundImage = Properties.Resources.startEnemyWeak;
                        startEnemy2.BackgroundImage = Properties.Resources.startEnemyWeak;
                        startEnemy3.BackgroundImage = Properties.Resources.startEnemyWeak;
                        startEnemy4.BackgroundImage = Properties.Resources.startEnemyWeak;

                        X1 += 8;
                        X2 += 8;
                        X3 += 8;
                        X4 += 8;
                        if (X1 > 0)
                        {
                            startplayer.X += 10;
                        }

                        if (startplayer.X >= 560)
                        {
                            startTimer.Enabled = false;
                            X1 = 750;
                            X2 = 795;
                            X3 = 840;
                            X4 = 885;
                            startplayer.X = 560;
                            startgame = "No";
                            startCount = 0;
                            startEnemy1.Visible = false;
                            startEnemy2.Visible = false;
                            startEnemy3.Visible = false;
                            startEnemy4.Visible = false;
                            menuPic.Visible = false;
                            startMove = "left";
                            situation = "playing";
                            playerTimer.Enabled = true;
                        }
                    }

                    startEnemy1.Location = new Point(X1, Y1);
                    startEnemy2.Location = new Point(X2, Y2);
                    startEnemy3.Location = new Point(X3, Y3);
                    startEnemy4.Location = new Point(X4, Y4);
                }
            }

            if (space == true)
            {
                startgame = "Yes";
            }

            if (startgame == "No")
            {
                if (startCount <= 30)
                {
                    menuLabel.Visible = true;
                }
                else if (startCount <= 50)
                {
                    menuLabel.Visible = false;
                    if (startCount == 50)
                    {
                        startCount = 0;
                    }
                }
            }
            else if (startgame == "Yes")
            {
                menuLabel.Visible = true;
                menuLabel.Text = "Now Loading...";
            }
            Refresh();
        }

        private void enemySoundTimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
