﻿namespace Ostranauts_Ship_Importer
{
    /// <summary>
    /// JSON Object container for serialized ship files
    /// </summary>
    public class Ship
    {
        public string strName { get; set; }
        public string strRegID { get; set; }
        public int nCurrentWaypoint { get; set; }
        public float fTimeEngaged { get; set; }
        public float fWearManeuver { get; set; }
        public float fWearAccrued { get; set; }
        public string[]? aProxCurrent { get; set; }
        public string[]? aProxIgnores { get; set; }
        public Aco[]? aCOs { get; set; }
        public Shipco shipCO { get; set; }
        public Aitem[] aItems { get; set; }
        public Ashallowpspec[]? aShallowPSpecs { get; set; }
        public Vshippos vShipPos { get; set; }
        public Objss objSS { get; set; }
        public Aroom[] aRooms { get; set; }
        public int DMGStatus { get; set; }
        public float fLastVisit { get; set; }
        public float fFirstVisit { get; set; }
        public float fAIDockingExpire { get; set; }
        public float fAIPauseTimer { get; set; }
        public bool bPrefill { get; set; }
        public bool bBreakInUsed { get; set; }
        public bool bNoCollisions { get; set; }
        public float dLastScanTime { get; set; }
        public bool bLocalAuthority { get; set; }
        public bool bAIShip { get; set; }
        public string make { get; set; }
        public string model { get; set; }
        public string year { get; set; }
        public string origin { get; set; }
        public string description { get; set; }
        public string designation { get; set; }
        public string publicName { get; set; }
        public string dimensions { get; set; }
        public string[] aRating { get; set; }
        public float fShallowMass { get; set; }
        public float fShallowRCSRemass { get; set; }
        public float fShallowRCSRemassMax { get; set; }
        public float fShallowFusionRemain { get; set; }
        public float fFusionThrustMax { get; set; }
        public float fFusionPelletMax { get; set; }
        public float fLastQuotedPrice { get; set; }
        public float fEpochNextGrav { get; set; }
        public float fBreakInMultiplier { get; set; }
        public float nRCSCount { get; set; }
        public float fShallowRotorStrength { get; set; }
        public int nRCSDistroCount { get; set; }
        public float fAeroCoefficient { get; set; }
        public int nDockCount { get; set; }
        public bool bFusionTorch { get; set; }
        public string strXPDR { get; set; }
        public bool bXPDRAntenna { get; set; }
        public bool bShipHidden { get; set; }
        public bool bIsUnderConstruction { get; set; }
        public int nO2PumpCount { get; set; }
        public Commdata? commData { get; set; }
        public int ShipType { get; set; }
        public int nConstructionProgress { get; set; }
        public int nInitConstructionProgress { get; set; }
    }

    public class Shipco
    {
        public string strID { get; set; }
        public string strCODef { get; set; }
        public bool bAlive { get; set; }
        public string[] aConds { get; set; }
        public string strCondID { get; set; }
        public int inventoryX { get; set; }
        public int inventoryY { get; set; }
        public float fDGasTemp { get; set; }
        public float fLastICOUpdate { get; set; }
        public int nDestTile { get; set; }
        public string strIdleAnim { get; set; }
        public string[] aMyShips { get; set; }
        public string strFriendlyName { get; set; }
        public string strRegIDLast { get; set; }
        public float fMSRedamageAmount { get; set; }
    }

    public class Vshippos
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Objss
    {
        public string boPORShip { get; set; }
        public float vPosx { get; set; }
        public float vPosy { get; set; }
        public float vBOOffsetx { get; set; }
        public float vBOOffsety { get; set; }
        public float vVelX { get; set; }
        public float vVelY { get; set; }
        public float fPathLastEpoch { get; set; }
        public Vaccin vAccIn { get; set; }
        public Vaccrcs vAccRCS { get; set; }
        public Vaccex vAccEx { get; set; }
        public float[] aPathRecentT { get; set; }
        public float[] aPathRecentX { get; set; }
        public float[] aPathRecentY { get; set; }
        public Vacclift vAccLift { get; set; }
        public Vaccdrag vAccDrag { get; set; }
        public float fRot { get; set; }
        public float fW { get; set; }
        public float fA { get; set; }
        public bool bBOLocked { get; set; }
        public bool bIsBO { get; set; }
        public bool bIsRegion { get; set; }
        public bool bIsNoFees { get; set; }
        public int size { get; set; }
        public bool bIgnoreGrav { get; set; }
    }

    public class Vaccin
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Vaccrcs
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Vaccex
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Vacclift
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Vaccdrag
    {
        public float x { get; set; }
        public float y { get; set; }
    }

    public class Commdata
    {
        public Amessage[]? aMessages { get; set; }
        public float dClearanceRequestTime { get; set; }
        public float dClearanceIssueTimestamp { get; set; }
        public bool bClearanceSquawkID { get; set; }
    }

    public class Aco
    {
        public string strID { get; set; }
        public string strCODef { get; set; }
        public bool bAlive { get; set; }
        public string[] aConds { get; set; }
        public string strCondID { get; set; }
        public int inventoryX { get; set; }
        public int inventoryY { get; set; }
        public float fDGasTemp { get; set; }
        public float fLastICOUpdate { get; set; }
        public int nDestTile { get; set; }
        public string strIdleAnim { get; set; }
        public string[] aMyShips { get; set; }
        public string strIMGPreview { get; set; }
        public string strFriendlyName { get; set; }
        public string strRegIDLast { get; set; }
        public float fMSRedamageAmount { get; set; }
    }

    public class Aitem
    {
        public string strName { get; set; }
        public float fX { get; set; }
        public float fY { get; set; }
        public float fRotation { get; set; }
        public string strID { get; set; }
        public Agpmsetting[]? aGPMSettings { get; set; }
        public string strSlotParentID { get; set; }
        public string strParentID { get; set; }
    }

    public class Agpmsetting
    {
        public string strName { get; set; }
        public string[]? dictGUIPropMap { get; set; }
    }

    public class Ashallowpspec
    {
        public string strName { get; set; }
        public float fX { get; set; }
        public float fY { get; set; }
        public float fRotation { get; set; }
        public string strID { get; set; }
        public Agpmsetting1[] aGPMSettings { get; set; }
    }

    public class Agpmsetting1
    {
        public string strName { get; set; }
        public string[] dictGUIPropMap { get; set; }
    }

    public class Aroom
    {
        public string strID { get; set; }
        public bool bVoid { get; set; }
        public int[] aTiles { get; set; }
        public string roomSpec { get; set; }
        public float roomValue { get; set; }
    }

    public class Amessage
    {
        public string strSenderRegId { get; set; }
        public string strRecieverRegId { get; set; }
        public float dAvailableTime { get; set; }
        public bool bRead { get; set; }
        public Iamessageinteraction iaMessageInteraction { get; set; }
        public string strMessageText { get; set; }
    }

    public class Iamessageinteraction
    {
        public string strName { get; set; }
        public string strChainStart { get; set; }
        public bool bLogged { get; set; }
        public bool bRaisedUI { get; set; }
        public bool bTryWalk { get; set; }
        public bool bCancel { get; set; }
        public bool bRetestItems { get; set; }
        public bool bManual { get; set; }
        public string objUs { get; set; }
        public string objThem { get; set; }
    }
}
